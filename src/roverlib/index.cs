namespace roverlib;
using Serilog;
using System.CommandLine;
using QuickType;
using NetMQ;
using NetMQ.Sockets;
using System.Net.Sockets;
using Rovercom = ProtobufMsgs;
using System;

public static class Rover
{
    public static void Run(MainCallback main, TerminationCallback onTerminate)
    {
        // parse args for debug mode and output path
        string[] args = Environment.GetCommandLineArgs();
        bool debug = false;
        string? path = null;

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--debug")
            {
                debug = true;
            }
            else if (args[i] == "--output" && i + 1 < args.Length)
            {
                path = args[i + 1];
                i++;
            }
        }

        // Fetch and parse service definition as injected by roverd
        string? json = Environment.GetEnvironmentVariable("ASE_SERVICE") ?? throw new Exception("No service definition found in environment variable ASE_SERVICE. Are you sure that this service is started by roverd?");
        Service service = Service.FromJson(json);

        // enable logging using Serilog
        SetUpLogging(debug, path, service.Name);

        // setup for catching SIGTERM, once setup this will run in the background; no active thread needed
        HandleSignals(onTerminate);

        // Create a configuration for this service that will be shared with the user program
        ServiceConfiguration configuration = new ServiceConfiguration(service);

        // support ota tuning in this thread
        // (the user program can fetch the latest value from the configuration)
        if (service.Tuning.Enabled == true)
        {
            TuningObj threadArgs = new TuningObj(service, configuration);
            Thread tuning = new Thread(OtaTuning);
            tuning.IsBackground = true;
            tuning.Start(threadArgs);
        }

        main(service, configuration);
    }

    // Configures log level and output
    private static void SetUpLogging(bool debug, string? outputPath, string serviceName = "Unknown")
    {
        string logFormat = "{Timestamp:HH:mm} {Level:u3} [{ServiceName}] {SourceFilePath}:{LineNumber} > {Message:lj}{NewLine}{Exception}";

        var temp = new LoggerConfiguration()
        .Enrich.WithProperty("ServiceName", serviceName)
        .WriteTo.Console(outputTemplate: logFormat);

        temp = debug ? temp.MinimumLevel.Debug() : temp.MinimumLevel.Information();

        if (outputPath != null)
        {
            temp = temp.WriteTo.File(outputPath,
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: logFormat);
        }

        Log.Logger = temp.CreateLogger();
    }

    private static void HandleSignals(TerminationCallback onTerminate)
    {
        // Catch SIGINT
        Console.CancelKeyPress += (sender, e) =>
        {
            Roverlog.Warn($"Signal received: {e.SpecialKey}");

            try
            {
                // callback to the service
                onTerminate(e.SpecialKey);
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Roverlog.Info($"Termination error: {ex.Message}");
                Environment.Exit(1);
            }
        };


        Roverlog.Info("Listening for signals...");
    }

    private static void OtaTuning(object? obj)
    {
        if (obj is TuningObj wrapper)
        {
            Service service = wrapper.service;
            ServiceConfiguration configuration = wrapper.configuration;

            while (true)
            {
                Roverlog.Info($"Attempting to subscribe to OTA tuning service at {service.Tuning.Address}");

                // Initialize socket to retrieve OTA tuning values from the service responsible for this
                SubscriberSocket? Socket = null;
                try
                {
                    Socket = new SubscriberSocket();
                    Socket.Connect(service.Tuning.Address);
                    Socket.Subscribe("");
                }
                catch (Exception e)
                {
                    Roverlog.Error($"Failed to connect/subscribe to OTA tuning service: {e.Message}");
                    if (Socket != null)
                    {
                        Socket.Close();
                        Socket.Dispose();
                    }
                    Thread.Sleep(5);
                    continue;
                }

                while (true)
                {
                    Roverlog.Info("Waiting for new tuning values");
                    // Receive new configuration, and update this in the shared configuration
                    byte[] res = Socket.ReceiveFrameBytes();

                    Roverlog.Info("Received new tuning values");

                    // convert from over-the-wire format to TuningState struct
                    Rovercom.TuningState tuning = Rovercom.TuningState.Parser.ParseFrom(res);

                    // Is the timestamp later than the last update?
                    if ((long)tuning.Timestamp <= configuration.lastUpdate)
                    {
                        Roverlog.Info("Received new tuning values with an outdated timestamp, ignoring...");
                        continue;
                    }

                    // Update the configuration (will ignore values that are not tunable)
                    for (int i = 0; i < tuning.DynamicParameters.Count; i++)
                    {
                        var p = tuning.DynamicParameters[i];
                        if (p.ParameterCase == Rovercom.TuningState.Types.Parameter.ParameterOneofCase.Number)
                        {
                            Roverlog.Info($" {p.Number.Key} : {p.Number.Value} Setting tuning value");
                            configuration.SetFloat(p.Number.Key, p.Number.Value);
                        }
                        else if (p.ParameterCase == Rovercom.TuningState.Types.Parameter.ParameterOneofCase.String)
                        {
                            Roverlog.Info($" {p.String.Key} : {p.String.Value} Setting tuning value");
                            configuration.SetString(p.String.Key, p.String.Value);
                        }
                        else
                        {
                            Roverlog.Warn("Unknown tuning value type");
                        }
                    }
                }
                
           }
        }
    }

    // Wrapper class for Tuning thread
    class TuningObj
    {
        public TuningObj(Service s, ServiceConfiguration c)
        {
            service = s;
            configuration = c;
        }
        public Service service;
        public ServiceConfiguration configuration;
    }

}



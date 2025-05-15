namespace roverlib;
using Serilog;
using System.CommandLine;
using QuickType;


public static class Rover
{
    public static void Run(MainCallback main, TerminationCallback onTerminate)
    {
        string[] args = Environment.GetCommandLineArgs();
        bool debug = false;
        string? path = null;

        for (int i = 0; i < args.Length; i++){
            if (args[i] == "--debug"){
                debug = true;
            }
            else if (args[i] == "--output" && i + 1 < args.Length){
                path = args[i + 1];
                i++;
            }
        }

        Console.WriteLine($"Debug mode: {debug}");
        Console.WriteLine($"Output file: {path}");

        Console.WriteLine("test");
        string? json = Environment.GetEnvironmentVariable("ASE_SERVICE") ?? throw new Exception("No service definition found in environment variable ASE_SERVICE. Are you sure that this service is started by roverd?");
        Service service = Service.FromJson(json);

        SetUpLogging(debug, path, service.Name);

        Console.WriteLine("after");
        HandleSignals(onTerminate);

        while (true)
        {
            
        }
    }

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
        Console.CancelKeyPress += (sender, e) =>
        {
            Roverlog.Warn($"Signal received: {e.SpecialKey}");

            try
            {
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

}



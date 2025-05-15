namespace roverlib;
using QuickType;
using Serilog;
using Serilog.Enrichers.WithCaller;
using System.Runtime.CompilerServices;
using System.CommandLine;
using System.CommandLine.Invocation;


public static class Rover
{
    public static void Run(string[] args){
        SetUpLogging(true, "/workspace/roverlib-c-sharp/logs.txt", "controller");
    }
    
    private static void SetUpLogging(bool debug, string? outputPath, string serviceName="Unknown"){
        string logFormat = "{Timestamp:HH:mm} {Level:u3} [{ServiceName}] {SourceFilePath}:{LineNumber} > {Message:lj}{NewLine}{Exception}";


        var temp = new LoggerConfiguration()
        .Enrich.WithProperty("ServiceName", serviceName)
        .WriteTo.Console(outputTemplate: logFormat);

        temp = debug ? temp.MinimumLevel.Debug() : temp.MinimumLevel.Information();

        if(outputPath != null){
            temp = temp.WriteTo.File(outputPath,
                        rollingInterval: RollingInterval.Day,
                        outputTemplate: logFormat);
        }
        
        Log.Logger = temp.CreateLogger();
    }

    // static private async int handleCL(string[] args){
    //     var nameOption = new Option<string>(
    //     "--name", 
    //     description: "The name to use");

    //     var rootCommand = new RootCommand("My tool");
    //     rootCommand.AddOption(nameOption);

    //     rootCommand.SetHandler((string name) =>
    //     {
    //         Roverlog.Info($"Name is {name}");
    //     }, nameOption);

    //     return await rootCommand.InvokeAsync(args);
    // }


}



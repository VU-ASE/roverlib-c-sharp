namespace roverlib;
using QuickType;
using Serilog;
using Serilog.Enrichers.WithCaller;
using System.Runtime.CompilerServices;


public static class Rover
{
    public static void Run(){
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
}



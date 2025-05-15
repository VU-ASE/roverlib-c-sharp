#r "/workspace/roverlib-c-sharp/src/roverlib/bin/Release/net8.0/roverlib.dll"
#r "/root/.nuget/packages/serilog/4.2.0/lib/netstandard2.0/Serilog.dll"
#r "/root/.nuget/packages/serilog.sinks.console/6.0.0/lib/netstandard2.0/Serilog.Sinks.Console.dll"
#r "/root/.nuget/packages/serilog.sinks.file/7.0.0/lib/netstandard2.0/Serilog.Sinks.File.dll"

using roverlib;
using System;
using QuickType;
using Serilog;
using Serilog;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.File;

public static class RoverService
{
    public static void Main()
    {
        Rover.Run(run, onTerminate);
        Roverlog.Debug("test");
    }

    private static void run(Service service, ServiceConfiguration configuration)
    {

    }

    private static void onTerminate(ConsoleSpecialKey signal)
    {
        Roverlog.Warn($"terminating: {signal.ToString()}");
    }


}

string json = File.ReadAllText("/workspace/roverlib-c-sharp/src/roverlib.tests/bootspectest.json");
Environment.SetEnvironmentVariable("ASE_SERVICE", json);

RoverService.Main();


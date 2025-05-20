#r "/workspace/roverlib-c-sharp/src/roverlib/bin/Release/netstandard2.1/roverlib.dll"
#r "/root/.nuget/packages/serilog.sinks.console/6.0.0/lib/netstandard2.0/Serilog.Sinks.Console.dll"
#r "/root/.nuget/packages/serilog.sinks.file/7.0.0/lib/netstandard2.0/Serilog.Sinks.File.dll"
#r "/root/.nuget/packages/netmq/4.0.1.15/lib/netstandard2.1/NetMQ.dll"
#r "/root/.nuget/packages/asyncio/0.1.69/lib/netstandard2.0/AsyncIO.dll"

using roverlib;
using System;
using QuickType;
using Serilog;
using Serilog.Sinks.SystemConsole;
using Serilog.Sinks.File;
using NetMQ;
using NetMQ.Sockets;
using Rovercom = ProtobufMsgs;

public static class RoverService
{


    public static void run(Service service, ServiceConfiguration configuration)
    {
        WriteStream ws = service.GetWriteStream("motor_movement");

        Rovercom.SensorOutput so = new Rovercom.SensorOutput();
        so.Status = 400;
        so.RpmOuput = new Rovercom.RpmSensorOutput();
        so.RpmOuput.LeftAngle = 2.0f;

        ws.Write(so);
        Roverlog.Info("written");

        while (true)
        {
            
        }
    }

    public static void onTerminate(ConsoleSpecialKey signal)
    {
        Roverlog.Warn($"terminating: {signal.ToString()}");
    }


}

string json = File.ReadAllText("/workspace/roverlib-c-sharp/src/roverlib.tests/bootspectest.json");
Environment.SetEnvironmentVariable("ASE_SERVICE", json);

var a = 1;

Rover.Run(RoverService.run, RoverService.onTerminate);
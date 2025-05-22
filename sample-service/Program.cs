using roverlib;
using QuickType;

using Rovercom = ProtobufMsgs;

public static class RoverService
{
    public static void run(Service service, ServiceConfiguration configuration)
   {
        Console.WriteLine("Inside run function");
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

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Before Roverlib");
        Rover.Run(RoverService.run, RoverService.onTerminate);
    }
}



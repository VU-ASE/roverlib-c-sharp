namespace roverlib.tests;
using roverlib;
using QuickType;
using Xunit;
using Xunit.Abstractions;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;
using Rovercom = ProtobufMsgs;

public class Basic
{
    private readonly ITestOutputHelper output;

    public Basic(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void FetchService()
    {


        this.output.WriteLine("Testing Basic Service injection");
        string json = File.ReadAllText("../../../bootspectest.json");
        Environment.SetEnvironmentVariable("ASE_SERVICE", json);

        Service service = Service.FromJson(Environment.GetEnvironmentVariable("ASE_SERVICE"));

        Assert.Equal("controller", service.Name);
        Assert.Equal("1.0.1", service.Version);
        Assert.Equal("navigation", service.Inputs[1].Service);
        Assert.Equal("debug_info", service.Inputs[0].Streams[1].Name);
        Assert.Equal("sensor_data", service.Outputs[1].Name);
        Assert.Equal("speed", service.Configuration[1].Name);
        Assert.Equal(100, service.Configuration[0].Value);
        Assert.Equal(true, service.Configuration[2].Tunable);
        Assert.Equal(true, service.Tuning.Enabled);

        ServiceConfiguration sc = new ServiceConfiguration(service);

        Rover.Run(null, null);

        Assert.Equal("debug", sc.GetString("log-level"));
        Assert.Equal("debug", sc.GetStringSafe("log-level"));
        Assert.Equal(100, sc.GetFloat("max-iterations"));
        Assert.Equal(100, sc.GetFloatSafe("max-iterations"));
        Assert.Equal(1.5, sc.GetFloat("speed"));

        sc.SetFloat("max-iterations", 101);
        sc.SetString("log-level", "info");

        Assert.Equal(101, sc.GetFloatSafe("max-iterations"));
        Assert.Equal("info", sc.GetStringSafe("log-level"));


    }

    // The following tests are not meant to pass, but are to check receiving/sending data indefinitely. Uncomment the return statements if you want these tests to pass 
    [Fact]
    public void Writing()
    {
        this.output.WriteLine("Testing Writing");
        string json = File.ReadAllText("../../../bootspectest.json");
        Environment.SetEnvironmentVariable("ASE_SERVICE", json);

        Service service = Service.FromJson(Environment.GetEnvironmentVariable("ASE_SERVICE"));
        ServiceConfiguration sc = new ServiceConfiguration(service);

        Rover.Run(null, null);

        WriteStream ws = service.GetWriteStream("motor_movement");
        //return
        while (true)
        {
            Rovercom.SensorOutput so = new Rovercom.SensorOutput();
            so.Status = 400;
            so.RpmOuput = new Rovercom.RpmSensorOutput();
            so.RpmOuput.LeftAngle = 2.0f;
            // so.SpeedOutput = new Rovercom.SpeedSensorOutput();
            // so.SpeedOutput.Rpm = 4;

            ws.Write(so);
            // ws.WriteBytes(System.Text.Encoding.UTF8.GetBytes("hello"));

            Roverlog.Info("writing");
            Thread.Sleep(300);
        }


    }

    [Fact]
    public void Reading()
    {
        this.output.WriteLine("Testing Reading");
        string json = File.ReadAllText("../../../bootspectest.json");
        Environment.SetEnvironmentVariable("ASE_SERVICE", json);

        Service service = Service.FromJson(Environment.GetEnvironmentVariable("ASE_SERVICE"));
        ServiceConfiguration sc = new ServiceConfiguration(service);

        Rover.Run(null, null);

        ReadStream rs = service.GetReadStream("imaging", "track_data");
        //return
        while (true)
        {
            Rovercom.SensorOutput so = rs.Read();
            Roverlog.Info($"incoming status: {so.Status}");
            Roverlog.Info($"Incoming left angle: {so.RpmOuput.LeftAngle}");
            // Roverlog.Info($"incoming speedoutput: {so.SpeedOutput.Rpm}");
            // Roverlog.Info("incoming: " + System.Text.Encoding.UTF8.GetString(rs.ReadBytes()));
            Thread.Sleep(300);
        }
    }


}
    






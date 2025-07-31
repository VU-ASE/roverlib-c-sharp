namespace roverlib.tests;

using roverlib;
using QuickType;
using Xunit;
using Xunit.Abstractions;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading;
using Rovercom = ProtobufMsgs;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf;
//
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
        return;
        while (true)
        {
            Rovercom.SensorOutput so = new Rovercom.SensorOutput();
            so.Status = 400;
            so.RpmOutput = new Rovercom.RpmSensorOutput();
            so.RpmOutput.LeftMotor.Speed = 2.0f;
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
        return;
        while (true)
        {
            Rovercom.SensorOutput so = rs.Read();
            Roverlog.Info($"incoming status: {so.Status}");
            Roverlog.Info($"Incoming left angle: {so.RpmOutput.LeftMotor.Rpm}");
            // Roverlog.Info($"incoming speedoutput: {so.SpeedOutput.Rpm}");
            // Roverlog.Info("incoming: " + System.Text.Encoding.UTF8.GetString(rs.ReadBytes()));
            Thread.Sleep(300);
        }
    }

    [Fact]
    public void Tuning()
    {
        string json = File.ReadAllText("/workspace/roverlib-c-sharp/src/roverlib.tests/bootspectest.json");
        Environment.SetEnvironmentVariable("ASE_SERVICE", json);
        string? json2 = Environment.GetEnvironmentVariable("ASE_SERVICE") ?? throw new Exception("No service definition found in environment variable ASE_SERVICE. Are you sure that this service is started by roverd?");
        Service service = Service.FromJson(json2);

        WriteStream ws = service.GetWriteStream("sensor_data");
        Rovercom.TuningState.Types.Parameter s = new Rovercom.TuningState.Types.Parameter();
        s.Number = new Rovercom.TuningState.Types.Parameter.Types.NumberParameter();
        s.Number.Key = "speed";
        s.Number.Value = 100;

        var tu = new Rovercom.TuningState();
        tu.Timestamp = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        tu.DynamicParameters.Add(s);
        return;
        while (true)
        {
            Thread.Sleep(100);
            ws.WriteBytes(tu.ToByteArray());
        }


        //         time.sleep(2)
        // context = zmq.Context()
        // socket = context.socket(zmq.PUB)
        // socket.bind("tcp://*:8829")

        // assert abs(configuration.GetFloatSafe("speed") - 1.5) < 0.01

        // tuning = rovercom.TuningState(timestamp=int(time.time() * 1000), dynamic_parameters=[
        //     rovercom.TuningStateParameter(number=rovercom.TuningStateParameterNumberParameter(key="speed",value=1.1))
        //     ]
        // ).SerializeToString()

        // for i in range(5):
        //     socket.send(tuning)
        //     time.sleep(0.05)


        // assert abs(configuration.GetFloatSafe("speed") - 1.1) < 0.01

    }


}







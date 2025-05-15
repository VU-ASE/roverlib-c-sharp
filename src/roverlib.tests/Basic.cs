namespace roverlib.tests;
using roverlib;
using QuickType;
using Xunit;
using Xunit.Abstractions;
using System.CommandLine;
using System.CommandLine.Invocation;

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

    // public static class Program{
    // public static void Main(string[] args){
        
    //     return;
    // }

    // private static void run(Service service, ServiceConfiguration configuration){

    // }

    // private static void onTerminate(){

    // }


}
    






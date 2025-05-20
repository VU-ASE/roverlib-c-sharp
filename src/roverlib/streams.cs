namespace roverlib;
using QuickType;
using Rovercom = ProtobufMsgs;
using NetMQ;
using NetMQ.Sockets;
using Google.Protobuf;

public class ServiceStream
{
    public string Address; //zmq address
    public NetMQSocket? Socket = null; // initialized as null, before lazy loading
    public long Bytes = 0; // amount of bytes read/written so far

    public ServiceStream(string address)
    {
        Address = address;
    }
}

public class WriteStream{

    private ServiceStream stream;
    public WriteStream(ServiceStream s){
        stream = s;
    }

    // Initial setup of the stream (done lazily, on the first write)
    private void Initialize()
    {

        // already initialized
        if (stream.Socket != null)
        {
            return;
        }

        try
        {
            // create a new socket
            stream.Socket = new PublisherSocket();
            stream.Socket.Bind(stream.Address);
        }
        catch (Exception e)
        {
            stream.Socket?.Dispose();
            Roverlog.Fatal($"Failed to create/bind write socket at {stream.Address}: {e.Message}");
            throw new Exception($"Failed to create/bind write socket at {stream.Address}: {e.Message}");
        }
        return;
    }

    // Write byte data to the stream
    public void WriteBytes(byte[] bytes)
    {
        if (stream.Socket == null)
        {
            Initialize();
        }

        try
        {
            // Write the data
            ((PublisherSocket)stream.Socket).SendFrame(bytes);
        }
        catch (Exception e)
        {
            Roverlog.Fatal($"Failed to write to stream: {e.Message}");
            throw new Exception($"Failed to write to stream: {e.Message}");
        }

        stream.Bytes += bytes.Length;
        return;
    }

    // Write a rovercom sensor output message to the stream
    public void Write(Rovercom.SensorOutput? output)
    {
        if (output == null)
        {
            Roverlog.Fatal("Cannot write nil output");
            throw new Exception("Cannot write nil output");
        }
        byte[] buf;
        try
        {
            // Convert to over-the-wire format
            buf = output.ToByteString().ToByteArray();
        }
        catch (Exception e)
        {
            Roverlog.Fatal($"Failed to serialize sensor data: {e.Message}");
            throw new Exception($"Failed to serialize sensor data: {e.Message}");
        }

        WriteBytes(buf);
    }

}

public class ReadStream{
    private ServiceStream stream;
    public ReadStream(ServiceStream s){
        stream = s;
    }

    // initial setup of the stream (done lazily, on the first read)
    private void Initialize()
    {
        // already initialized
        if (stream.Socket != null)
        {
            return;
        }

        try
        {
            // create a new socket
            var temp = new SubscriberSocket();
            temp.Connect(stream.Address);
            temp.Subscribe("");
            stream.Socket = temp;
        }
        catch (Exception e)
        {
            Roverlog.Fatal($"Failed to create/connect/subscribe read socket at {stream.Address}: {e.Message}");
            throw new Exception($"Failed to create/connect/subscribe read socket at {stream.Address}: {e.Message}");
        }
        return;
    }

    // Read byte data from the stream
    public byte[] ReadBytes(){
        if(stream.Socket == null){
            Initialize();
        }

        try{
            // Read the data
            byte[] data = stream.Socket.ReceiveFrameBytes();
            stream.Bytes += data.Length;
            return data;
        }
        catch(Exception e){
            Roverlog.Fatal($"Failed to read from stream: {e.Message}");
            throw new Exception($"Failed to read from stream: {e.Message}");
        }
    }

    // Read a rovercom sensor output message from the stream
    public Rovercom.SensorOutput Read()
    {
        // Read the Data
        byte[] buf = ReadBytes();
        Rovercom.SensorOutput output;
        try
        {
            // convert from over-the-wire format
            output = Rovercom.SensorOutput.Parser.ParseFrom(buf);
        }
        catch (Exception e)
        {
            Roverlog.Fatal($"Failed to parse sensor data: {e.Message}");
            throw new Exception($"Failed to parse sensor data: {e.Message}");
        }
        return output;
    }
    
}

public static class ServiceExtend{
    // Map of all already handed out streams to the user program (to preserve singletons)
    private readonly static Dictionary<string, WriteStream> WriteStreams = new Dictionary<string, WriteStream>();
    private readonly static Dictionary<string, ReadStream> ReadStreams = new Dictionary<string, ReadStream>();

    // Get a stream that you can write to (i.e. an output stream).
    // this function throws an error if the stream does not exist.
    public static WriteStream GetWriteStream(this Service s, string name)
    {
        // Is this stream already handed out?
        if (WriteStreams.ContainsKey(name))
        {
            return WriteStreams[name];
        }

        // Does this stream exist?
        for (int i = 0; i < s.Outputs.Length; i++)
        {
            var output = s.Outputs[i];
            if (output.Name == name)
            {

                // ZMQ wants to bind write streams to tcp://*:port addresses, so if roverd gave us a localhost, we need to change it to *
                var address = output.Address.Replace("localhost", "*");

                // Create a new stream
                ServiceStream newStream = new ServiceStream(address);

                WriteStream res = new WriteStream(newStream);
                WriteStreams[name] = res;
                return res;
            }
        }

        Roverlog.Fatal($"Output stream {name} does not exist. Update your program code or service.yaml");
        throw new Exception($"Output stream {name} does not exist. Update your program code or service.yaml");
    }

    // Get a stream that you can read from (i.e. an input stream).
    // This function throws an error if the stream does not exist.
    public static ReadStream GetReadStream(this Service s, string service, string name)
    {
        string StreamName = $"{service}-{name}";

        // Is this stream already handed out?
        if (ReadStreams.ContainsKey(StreamName))
        {
            return ReadStreams[StreamName];
        }

        // Does this stream exist
        for (int i = 0; i < s.Inputs.Length; i++)
        {
            var input = s.Inputs[i];
            if (input.Service == service)
            {
                for (int j = 0; j < input.Streams.Length; j++)
                {
                    var stream = input.Streams[i];
                    if (stream.Name == name)
                    {
                        // Create a new stream
                        ServiceStream newStream = new ServiceStream(stream.Address);

                        ReadStream res = new ReadStream(newStream);
                        ReadStreams[StreamName] = res;
                        return res;
                    }

                }

            }

        }

        Roverlog.Fatal($"Input stream {StreamName} does not exist. Update your program code or service.yaml");
        throw new Exception($"Input stream {StreamName} does not exist. Update your program code or service.yaml");
    }
    
}







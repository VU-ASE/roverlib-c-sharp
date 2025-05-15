namespace roverlib;
using QuickType;
using Rovercom = ProtobufMsgs;
using NetMQ;
using NetMQ.Sockets;
using System.Net.Sockets;
using Google.Protobuf;

public class ServiceStream
{
    public string Address { get; }
    public NetMQSocket? Socket = null;
    public long Bytes = 0;

    public ServiceStream(string address)
    {
        Address = address;
    }
}

public class WriteStream{

    public ServiceStream stream;
    WriteStream(ServiceStream s){
        stream = s;
    }

    private void Initialize(){
        if(stream.Socket != null){
            return;
        }

        try{
            stream.Socket = new PublisherSocket();
            stream.Socket.Bind(stream.Address);
        }
        catch(Exception e){
            stream.Socket?.Dispose();
            Roverlog.Fatal($"Failed to create/bind write socket at {stream.Address}: {e.Message}");
            throw new Exception($"Failed to create/bind write socket at {stream.Address}: {e.Message}");
        }
        return;
    }

    public void WriteBytes(byte[] bytes){
        if(stream.Socket == null){
            Initialize();
        }
        
        try{
            ((PublisherSocket)stream.Socket).SendFrame(bytes);
        }
        catch(Exception e){
            Roverlog.Fatal($"Failed to write to stream: {e.Message}");
            throw new Exception($"Failed to write to stream: {e.Message}");
        }
        
        stream.Bytes += bytes.Length;
        return;
    }

    public void Write(Rovercom.SensorOutput? output){
        if(output == null){
            Roverlog.Fatal("Cannot write nil output");
            throw new Exception("Cannot write nil output");
        }
        byte[] buf;
        try{
            buf = output.ToByteString().ToByteArray();
        }
        catch(Exception e){
            Roverlog.Fatal($"Failed to serialize sensor data: {e.Message}");
            throw new Exception($"Failed to serialize sensor data: {e.Message}");
        }

        WriteBytes(buf);
    }

}

public class ReadStream{
    private ServiceStream stream;
    ReadStream(ServiceStream s){
        stream = s;
    }

    private void Initialize(){
        if(stream.Socket != null){
            return;
        }

        try{
            var temp = new SubscriberSocket();
            temp.Connect(stream.Address);
            temp.Subscribe("");
            stream.Socket = temp;
        }
        catch(Exception e){
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

    public Rovercom.SensorOutput Read(){
        // Read the Data
        byte[] buf = ReadBytes();
        Rovercom.SensorOutput output;
        try{
            // convert from over-the-wire format
            output = Rovercom.SensorOutput.Parser.ParseFrom(buf);
        }
        catch(Exception e){
            Roverlog.Fatal($"Failed to parse sensor data: {e.Message}");
            throw new Exception($"Failed to parse sensor data: {e.Message}");
        }
        return output;
    }
    
}   





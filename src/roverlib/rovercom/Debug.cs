// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: debug/debug.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtobufMsgs {

  /// <summary>Holder for reflection information generated from debug/debug.proto</summary>
  public static partial class DebugReflection {

    #region Descriptor
    /// <summary>File descriptor for debug/debug.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DebugReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFkZWJ1Zy9kZWJ1Zy5wcm90bxINcHJvdG9idWZfbXNncyIuChFTZXJ2aWNl",
            "SWRlbnRpZmllchIMCgRuYW1lGAEgASgJEgsKA3BpZBgCIAEoBSIwCg9TZXJ2",
            "aWNlRW5kcG9pbnQSDAoEbmFtZRgBIAEoCRIPCgdhZGRyZXNzGAIgASgJIpMB",
            "CgtEZWJ1Z091dHB1dBIxCgdzZXJ2aWNlGAEgASgLMiAucHJvdG9idWZfbXNn",
            "cy5TZXJ2aWNlSWRlbnRpZmllchIwCghlbmRwb2ludBgCIAEoCzIeLnByb3Rv",
            "YnVmX21zZ3MuU2VydmljZUVuZHBvaW50Eg4KBnNlbnRBdBgEIAEoAxIPCgdt",
            "ZXNzYWdlGAMgASgMQg5aDGFzZS9wYl9kZWJ1Z2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsgs.ServiceIdentifier), global::ProtobufMsgs.ServiceIdentifier.Parser, new[]{ "Name", "Pid" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsgs.ServiceEndpoint), global::ProtobufMsgs.ServiceEndpoint.Parser, new[]{ "Name", "Address" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsgs.DebugOutput), global::ProtobufMsgs.DebugOutput.Parser, new[]{ "Service", "Endpoint", "SentAt", "Message" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Used to identify a service within the pipeline
  /// </summary>
  public sealed partial class ServiceIdentifier : pb::IMessage<ServiceIdentifier> {
    private static readonly pb::MessageParser<ServiceIdentifier> _parser = new pb::MessageParser<ServiceIdentifier>(() => new ServiceIdentifier());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ServiceIdentifier> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsgs.DebugReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceIdentifier() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceIdentifier(ServiceIdentifier other) : this() {
      name_ = other.name_;
      pid_ = other.pid_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceIdentifier Clone() {
      return new ServiceIdentifier(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "pid" field.</summary>
    public const int PidFieldNumber = 2;
    private int pid_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Pid {
      get { return pid_; }
      set {
        pid_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ServiceIdentifier);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ServiceIdentifier other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Pid != other.Pid) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Pid != 0) hash ^= Pid.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Pid != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Pid);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Pid != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Pid);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ServiceIdentifier other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Pid != 0) {
        Pid = other.Pid;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 16: {
            Pid = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// An endpoint that is made available by a service
  /// </summary>
  public sealed partial class ServiceEndpoint : pb::IMessage<ServiceEndpoint> {
    private static readonly pb::MessageParser<ServiceEndpoint> _parser = new pb::MessageParser<ServiceEndpoint>(() => new ServiceEndpoint());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ServiceEndpoint> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsgs.DebugReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceEndpoint() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceEndpoint(ServiceEndpoint other) : this() {
      name_ = other.name_;
      address_ = other.address_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ServiceEndpoint Clone() {
      return new ServiceEndpoint(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    /// <summary>
    /// the identifier to select this endpoint
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "address" field.</summary>
    public const int AddressFieldNumber = 2;
    private string address_ = "";
    /// <summary>
    /// the zmq address to connect to
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Address {
      get { return address_; }
      set {
        address_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ServiceEndpoint);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ServiceEndpoint other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Address != other.Address) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Address.Length != 0) hash ^= Address.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Address.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Address);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Address.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Address);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ServiceEndpoint other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Address.Length != 0) {
        Address = other.Address;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 18: {
            Address = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  ///
  /// When the transceivers picks up a SensorOutput from a service, it will wrap it in a ServiceMessage message,
  /// so that the receiver can determine from which process the message originated
  /// </summary>
  public sealed partial class DebugOutput : pb::IMessage<DebugOutput> {
    private static readonly pb::MessageParser<DebugOutput> _parser = new pb::MessageParser<DebugOutput>(() => new DebugOutput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<DebugOutput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsgs.DebugReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DebugOutput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DebugOutput(DebugOutput other) : this() {
      service_ = other.service_ != null ? other.service_.Clone() : null;
      endpoint_ = other.endpoint_ != null ? other.endpoint_.Clone() : null;
      sentAt_ = other.sentAt_;
      message_ = other.message_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public DebugOutput Clone() {
      return new DebugOutput(this);
    }

    /// <summary>Field number for the "service" field.</summary>
    public const int ServiceFieldNumber = 1;
    private global::ProtobufMsgs.ServiceIdentifier service_;
    /// <summary>
    /// The service that sent the message
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtobufMsgs.ServiceIdentifier Service {
      get { return service_; }
      set {
        service_ = value;
      }
    }

    /// <summary>Field number for the "endpoint" field.</summary>
    public const int EndpointFieldNumber = 2;
    private global::ProtobufMsgs.ServiceEndpoint endpoint_;
    /// <summary>
    /// The endpoint in this service that sent the message
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::ProtobufMsgs.ServiceEndpoint Endpoint {
      get { return endpoint_; }
      set {
        endpoint_ = value;
      }
    }

    /// <summary>Field number for the "sentAt" field.</summary>
    public const int SentAtFieldNumber = 4;
    private long sentAt_;
    /// <summary>
    /// Time in milliseconds since epoch when the message was sent
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public long SentAt {
      get { return sentAt_; }
      set {
        sentAt_ = value;
      }
    }

    /// <summary>Field number for the "message" field.</summary>
    public const int MessageFieldNumber = 3;
    private pb::ByteString message_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as DebugOutput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(DebugOutput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Service, other.Service)) return false;
      if (!object.Equals(Endpoint, other.Endpoint)) return false;
      if (SentAt != other.SentAt) return false;
      if (Message != other.Message) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (service_ != null) hash ^= Service.GetHashCode();
      if (endpoint_ != null) hash ^= Endpoint.GetHashCode();
      if (SentAt != 0L) hash ^= SentAt.GetHashCode();
      if (Message.Length != 0) hash ^= Message.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (service_ != null) {
        output.WriteRawTag(10);
        output.WriteMessage(Service);
      }
      if (endpoint_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(Endpoint);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Message);
      }
      if (SentAt != 0L) {
        output.WriteRawTag(32);
        output.WriteInt64(SentAt);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (service_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Service);
      }
      if (endpoint_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Endpoint);
      }
      if (SentAt != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(SentAt);
      }
      if (Message.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Message);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(DebugOutput other) {
      if (other == null) {
        return;
      }
      if (other.service_ != null) {
        if (service_ == null) {
          Service = new global::ProtobufMsgs.ServiceIdentifier();
        }
        Service.MergeFrom(other.Service);
      }
      if (other.endpoint_ != null) {
        if (endpoint_ == null) {
          Endpoint = new global::ProtobufMsgs.ServiceEndpoint();
        }
        Endpoint.MergeFrom(other.Endpoint);
      }
      if (other.SentAt != 0L) {
        SentAt = other.SentAt;
      }
      if (other.Message.Length != 0) {
        Message = other.Message;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            if (service_ == null) {
              Service = new global::ProtobufMsgs.ServiceIdentifier();
            }
            input.ReadMessage(Service);
            break;
          }
          case 18: {
            if (endpoint_ == null) {
              Endpoint = new global::ProtobufMsgs.ServiceEndpoint();
            }
            input.ReadMessage(Endpoint);
            break;
          }
          case 26: {
            Message = input.ReadBytes();
            break;
          }
          case 32: {
            SentAt = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

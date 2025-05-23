// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: outputs/lux.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtobufMsgs {

  /// <summary>Holder for reflection information generated from outputs/lux.proto</summary>
  public static partial class LuxReflection {

    #region Descriptor
    /// <summary>File descriptor for outputs/lux.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static LuxReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChFvdXRwdXRzL2x1eC5wcm90bxINcHJvdG9idWZfbXNncyIeCg9MdXhTZW5z",
            "b3JPdXRwdXQSCwoDbHV4GAEgASgFQhBaDmFzZS9wYl9vdXRwdXRzYgZwcm90",
            "bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsgs.LuxSensorOutput), global::ProtobufMsgs.LuxSensorOutput.Parser, new[]{ "Lux" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class LuxSensorOutput : pb::IMessage<LuxSensorOutput> {
    private static readonly pb::MessageParser<LuxSensorOutput> _parser = new pb::MessageParser<LuxSensorOutput>(() => new LuxSensorOutput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<LuxSensorOutput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsgs.LuxReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LuxSensorOutput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LuxSensorOutput(LuxSensorOutput other) : this() {
      lux_ = other.lux_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public LuxSensorOutput Clone() {
      return new LuxSensorOutput(this);
    }

    /// <summary>Field number for the "lux" field.</summary>
    public const int LuxFieldNumber = 1;
    private int lux_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Lux {
      get { return lux_; }
      set {
        lux_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as LuxSensorOutput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(LuxSensorOutput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Lux != other.Lux) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Lux != 0) hash ^= Lux.GetHashCode();
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
      if (Lux != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Lux);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Lux != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Lux);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(LuxSensorOutput other) {
      if (other == null) {
        return;
      }
      if (other.Lux != 0) {
        Lux = other.Lux;
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
          case 8: {
            Lux = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

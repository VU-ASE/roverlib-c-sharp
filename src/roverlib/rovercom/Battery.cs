// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: outputs/battery.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace ProtobufMsgs {

  /// <summary>Holder for reflection information generated from outputs/battery.proto</summary>
  public static partial class BatteryReflection {

    #region Descriptor
    /// <summary>File descriptor for outputs/battery.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static BatteryReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChVvdXRwdXRzL2JhdHRlcnkucHJvdG8SDXByb3RvYnVmX21zZ3MiXQoTQmF0",
            "dGVyeVNlbnNvck91dHB1dBIcChRjdXJyZW50T3V0cHV0Vm9sdGFnZRgBIAEo",
            "AhITCgt3YXJuVm9sdGFnZRgCIAEoAhITCgtraWxsVm9sdGFnZRgDIAEoAkIQ",
            "Wg5hc2UvcGJfb3V0cHV0c2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::ProtobufMsgs.BatterySensorOutput), global::ProtobufMsgs.BatterySensorOutput.Parser, new[]{ "CurrentOutputVoltage", "WarnVoltage", "KillVoltage" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///
  /// This is the message format that a battery service can send out. It contains information about the battery's current state.
  /// </summary>
  public sealed partial class BatterySensorOutput : pb::IMessage<BatterySensorOutput> {
    private static readonly pb::MessageParser<BatterySensorOutput> _parser = new pb::MessageParser<BatterySensorOutput>(() => new BatterySensorOutput());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<BatterySensorOutput> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::ProtobufMsgs.BatteryReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BatterySensorOutput() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BatterySensorOutput(BatterySensorOutput other) : this() {
      currentOutputVoltage_ = other.currentOutputVoltage_;
      warnVoltage_ = other.warnVoltage_;
      killVoltage_ = other.killVoltage_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public BatterySensorOutput Clone() {
      return new BatterySensorOutput(this);
    }

    /// <summary>Field number for the "currentOutputVoltage" field.</summary>
    public const int CurrentOutputVoltageFieldNumber = 1;
    private float currentOutputVoltage_;
    /// <summary>
    /// The current voltage of the battery in volts
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float CurrentOutputVoltage {
      get { return currentOutputVoltage_; }
      set {
        currentOutputVoltage_ = value;
      }
    }

    /// <summary>Field number for the "warnVoltage" field.</summary>
    public const int WarnVoltageFieldNumber = 2;
    private float warnVoltage_;
    /// <summary>
    /// The voltage at which the framework will warn the user about low battery
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float WarnVoltage {
      get { return warnVoltage_; }
      set {
        warnVoltage_ = value;
      }
    }

    /// <summary>Field number for the "killVoltage" field.</summary>
    public const int KillVoltageFieldNumber = 3;
    private float killVoltage_;
    /// <summary>
    /// The voltage at which the framework will shut down the debix to prevent undercharge
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float KillVoltage {
      get { return killVoltage_; }
      set {
        killVoltage_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as BatterySensorOutput);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(BatterySensorOutput other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(CurrentOutputVoltage, other.CurrentOutputVoltage)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(WarnVoltage, other.WarnVoltage)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(KillVoltage, other.KillVoltage)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (CurrentOutputVoltage != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(CurrentOutputVoltage);
      if (WarnVoltage != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(WarnVoltage);
      if (KillVoltage != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(KillVoltage);
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
      if (CurrentOutputVoltage != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(CurrentOutputVoltage);
      }
      if (WarnVoltage != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(WarnVoltage);
      }
      if (KillVoltage != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(KillVoltage);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (CurrentOutputVoltage != 0F) {
        size += 1 + 4;
      }
      if (WarnVoltage != 0F) {
        size += 1 + 4;
      }
      if (KillVoltage != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(BatterySensorOutput other) {
      if (other == null) {
        return;
      }
      if (other.CurrentOutputVoltage != 0F) {
        CurrentOutputVoltage = other.CurrentOutputVoltage;
      }
      if (other.WarnVoltage != 0F) {
        WarnVoltage = other.WarnVoltage;
      }
      if (other.KillVoltage != 0F) {
        KillVoltage = other.KillVoltage;
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
          case 13: {
            CurrentOutputVoltage = input.ReadFloat();
            break;
          }
          case 21: {
            WarnVoltage = input.ReadFloat();
            break;
          }
          case 29: {
            KillVoltage = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

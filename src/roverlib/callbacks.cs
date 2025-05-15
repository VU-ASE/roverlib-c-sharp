using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using QuickType;

// Delegate for a function taking Service and ServiceConfiguration, returning void


// Delegate for a function taking a signal and returning void
public delegate void TerminationCallback(PosixSignalContext signalContext);

namespace roverlib;
using System;
using System.Diagnostics;
using System.Threading;
using QuickType;

public delegate void MainCallback(Service service, ServiceConfiguration configuration);

public delegate void TerminationCallback(ConsoleSpecialKey signal);

namespace roverlib;
using Serilog;
using System.Runtime.CompilerServices;

public static class Roverlog
{
    public static void Debug(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log.ForContext("SourceFilePath", System.IO.Path.GetFileName(file))
           .ForContext("LineNumber", line)
           .Debug(message);
    }

    public static void Info(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log.ForContext("SourceFilePath", System.IO.Path.GetFileName(file))
           .ForContext("LineNumber", line)
           .Information(message);
    }

    public static void Warn(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log.ForContext("SourceFilePath", System.IO.Path.GetFileName(file))
           .ForContext("LineNumber", line)
           .Warning(message);
    }

    public static void Error(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log.ForContext("SourceFilePath", System.IO.Path.GetFileName(file))
           .ForContext("LineNumber", line)
           .Error(message);
    }

    public static void Fatal(string message,
        [CallerFilePath] string file = "",
        [CallerLineNumber] int line = 0)
    {
        Log.ForContext("SourceFilePath", System.IO.Path.GetFileName(file))
           .ForContext("LineNumber", line)
           .Fatal(message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Loggers;
public class Logger : ILogger
{
    public void Log(string message, params object?[] arg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(ILogger.LogMessage + message, arg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Error(string message, params object?[] arg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ILogger.ErrorMessage + message, arg);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void Warn(string message, params object?[] arg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(ILogger.WarnMessage + message, arg);
        Console.ForegroundColor = ConsoleColor.White;
    }
}

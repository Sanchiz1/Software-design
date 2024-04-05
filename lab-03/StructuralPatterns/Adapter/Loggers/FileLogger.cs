using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Loggers;
public class FileLogger : ILogger
{
    private FileWriter fileWriter;

    public FileLogger(FileWriter fileWriter)
    {
        this.fileWriter = fileWriter;
    }

    public void Log(string message, params object?[] arg)
    {
        fileWriter.WriteLine(ILogger.LogMessage + message, arg);
    }

    public void Error(string message, params object?[] arg)
    {
        fileWriter.WriteLine(ILogger.ErrorMessage + message, arg);
    }

    public void Warn(string message, params object?[] arg)
    {
        fileWriter.WriteLine(ILogger.WarnMessage + message, arg);
    }
}

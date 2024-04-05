using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Loggers;
public interface ILogger
{
    protected static string LogMessage = string.Format("{0, 10}", "info: ");
    protected static string ErrorMessage = string.Format("{0, 10}", "error: ");
    protected static string WarnMessage = string.Format("{0, 10}", "warning: ");

    void Log(string message, params object?[] arg);

    void Error(string message, params object?[] arg);

    void Warn(string message, params object?[] arg);
}

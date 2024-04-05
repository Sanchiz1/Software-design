using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy;
public interface ILogger
{
    void Info(string message, params object?[] args);
    void Error(string message, params object?[] args);
}

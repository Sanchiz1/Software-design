using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.SmartText;
public class SmartTextChecker : ISmartTextReader
{
    private SmartTextReader _smartTextReader;
    private ILogger _logger;

    public SmartTextChecker(SmartTextReader smartTextReader, ILogger logger)
    {
        this._smartTextReader = smartTextReader;
        _logger = logger;
    }

    public char[][] ReadTextFile(string filePath)
    {
        this._logger.Info("Reading file {0}", filePath);

        char[][] result = _smartTextReader.ReadTextFile(filePath);

        this._logger.Info(
            "Opened file {0}, lines count: {1}, chars count : {2}",
            filePath,
            result.Length,
            result.Sum(line => line.Length));

        return result;
    }
}

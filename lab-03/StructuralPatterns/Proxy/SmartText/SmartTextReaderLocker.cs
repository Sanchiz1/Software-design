using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proxy.SmartText;
public class SmartTextReaderLocker : ISmartTextReader
{
    private SmartTextReader _smartTextReader;
    private ILogger _logger;
    private Regex _restrictRegex;

    public SmartTextReaderLocker(SmartTextReader smartTextReader, ILogger logger, string regexPattern)
    {
        this._smartTextReader = smartTextReader;
        _logger = logger;
        _restrictRegex = new Regex(regexPattern);
    }

    public char[][] ReadTextFile(string filePath)
    {
        if (this._restrictRegex.IsMatch(filePath))
        {
            this._logger.Error("Failed to read file {0}, access denied", filePath);
            return null;
        }

        return _smartTextReader.ReadTextFile(filePath);
    }
}

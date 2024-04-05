using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter;
public class FileWriter
{
    public string FilePath { get; private set; } = default!;

    public FileWriter(string filePath)
    {
        FilePath = filePath;
    }

    public FileWriter() { }

    public void SetFilePath(string filePath)
    {
        FilePath = filePath;
    }

    public void Write(string message, params object?[] arg)
    {
        StreamWriter file = new StreamWriter(FilePath, true);
        file.Write(message, arg);
        file.Close();
    }

    public void WriteLine(string message, params object?[] arg)
    {
        StreamWriter file = new StreamWriter(FilePath, true);
        file.WriteLine(message, arg);
        file.Close();
    }
}

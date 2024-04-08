using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ImageProvider;
public class FileImageProvider : IImageProvider
{
    public async Task<byte[]> GetImage(string path)
    {
        return await File.ReadAllBytesAsync(path);
    }
}

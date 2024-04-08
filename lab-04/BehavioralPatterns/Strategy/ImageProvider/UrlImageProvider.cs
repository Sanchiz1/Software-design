using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ImageProvider;
public class UrlImageProvider : IImageProvider
{
    public async Task<byte[]> GetImage(string path)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetByteArrayAsync(path);
    }
}

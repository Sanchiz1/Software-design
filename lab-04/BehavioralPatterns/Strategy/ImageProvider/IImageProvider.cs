using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.ImageProvider;
public interface IImageProvider
{
    Task<byte[]> GetImage(string path);
}

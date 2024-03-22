using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Interfaces;
public interface ISmartphone
{
    IEnumerable<string> GetSupportedPhotoResolutions();
    string GetDetails();
}

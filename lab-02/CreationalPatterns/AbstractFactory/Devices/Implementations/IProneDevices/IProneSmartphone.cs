using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.IProneDevices;
public class IProneSmartphone : ISmartphone
{

    public IEnumerable<string> GetSupportedPhotoResolutions()
    {
        return ["720x1280", "2560x1440", "1920x1080"];
    }
    public string GetDetails()
    {
        return $"IProne smartphone, supported formats: {GetSupportedPhotoResolutions().Count()} ";
    }
}

using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.BalaxyDevices;
public class BalaxySmartphone : ISmartphone
{

    public IEnumerable<string> GetSupportedPhotoResolutions()
    {
        return ["720x1280", "2560x1440"];
    }
    public string GetDetails()
    {
        return $"Balaxy smartphone, supported formats: {GetSupportedPhotoResolutions().Count()} ";
    }
}

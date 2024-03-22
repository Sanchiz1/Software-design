using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.KiaomiDevices;
public class KiaomiSmartphone : ISmartphone
{

    public IEnumerable<string> GetSupportedPhotoResolutions()
    {
        return ["720x1280", "480x800"];
    }
    public string GetDetails()
    {
        return $"Kiaomi smartphone, supported formats: {GetSupportedPhotoResolutions().Count()} ";
    }
}

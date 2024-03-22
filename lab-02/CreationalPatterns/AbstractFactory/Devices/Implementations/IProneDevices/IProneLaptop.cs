using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.IProneDevices;
public class IProneLaptop : ILaptop
{
    public IEnumerable<string> GetSupportedOperatingSystems()
    {
        return ["GacOs"];
    }

    public string GetDetails()
    {
        return $"IProne laptop, supported formats: {GetSupportedOperatingSystems().Count()} ";
    }
}

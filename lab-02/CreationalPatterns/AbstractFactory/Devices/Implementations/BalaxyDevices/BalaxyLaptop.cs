using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.BalaxyDevices;
public class BalaxyLaptop : ILaptop
{
    public IEnumerable<string> GetSupportedOperatingSystems()
    {
        return ["Nulix", "Shindows"];
    }

    public string GetDetails()
    {
        return $"Balaxy laptop, supported formats: {GetSupportedOperatingSystems().Count()} ";
    }
}

using AbstractFactory.Devices.Implementations.BalaxyDevices;
using AbstractFactory.Devices.Implementations.KiaomiDevices;
using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories;
public class BalaxyFactory : IDeviceFactory
{
    public ILaptop CreateLaptop()
    {
        return new BalaxyLaptop();
    }

    public IEbook CreateEBook()
    {
        return new BalaxyEBook();
    }

    public ISmartphone CreateSmartphone()
    {
        return new BalaxySmartphone();
    }
}
using AbstractFactory.Devices.Implementations.IProneDevices;
using AbstractFactory.Devices.Implementations.KiaomiDevices;
using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories;

public class IProneFactory : IDeviceFactory
{
    public ILaptop CreateLaptop()
    {
        return new IProneLaptop();
    }

    public IEbook CreateEBook()
    {
        return new IProneEBook();
    }

    public ISmartphone CreateSmartphone()
    {
        return new IProneSmartphone();
    }
}
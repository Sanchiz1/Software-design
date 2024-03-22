using AbstractFactory.Devices.Implementations.KiaomiDevices;
using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories;
public class KiaomiFactory : IDeviceFactory
{
    public ILaptop CreateLaptop()
    {
        return new KiaomiLaptop();
    }

    public IEbook CreateEBook()
    {
        return new KiaomiEBook();
    }

    public ISmartphone CreateSmartphone()
    {
        return new KiaomiSmartphone();
    }
}

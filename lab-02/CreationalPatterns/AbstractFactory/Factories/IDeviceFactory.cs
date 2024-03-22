using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factories;
public interface IDeviceFactory
{
    ILaptop CreateLaptop();
    IEbook CreateEBook();
    ISmartphone CreateSmartphone();
}

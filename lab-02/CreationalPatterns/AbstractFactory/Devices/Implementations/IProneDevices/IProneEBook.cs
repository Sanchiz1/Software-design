using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.IProneDevices;
public class IProneEBook : IEbook
{
    public IEnumerable<string> GetSupportedFormats()
    {
        return ["EPUB", "PDF"];
    }

    public string GetDetails()
    {
        return $"IProne EBook, supported formats: {GetSupportedFormats().Count()} ";
    }
}

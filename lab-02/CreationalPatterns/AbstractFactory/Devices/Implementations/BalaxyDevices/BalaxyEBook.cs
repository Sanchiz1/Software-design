using AbstractFactory.Devices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Implementations.BalaxyDevices;
public class BalaxyEBook : IEbook
{
    public IEnumerable<string> GetSupportedFormats()
    {
        return ["EPUB", "PDF", "TXT"];
    }

    public string GetDetails()
    {
        return $"Balaxy EBook, supported formats: {GetSupportedFormats().Count()} ";
    }
}

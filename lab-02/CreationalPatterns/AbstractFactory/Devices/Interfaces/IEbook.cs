using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Devices.Interfaces;
public interface IEbook
{
    IEnumerable<string> GetSupportedFormats();
    string GetDetails();
}

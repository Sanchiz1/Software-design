using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite;
public interface ILightNode
{
    public string GetOuterHTML(int depth = 0);
    public string GetInnerHTML(int depth = 1);
}
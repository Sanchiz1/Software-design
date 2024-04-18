using Composite.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite;
public interface ILightNode
{
    string GetOuterHTML(int depth = 0);
    string GetInnerHTML(int depth = 1);
    void Accept(ILightNodeVisitor visitor);
}
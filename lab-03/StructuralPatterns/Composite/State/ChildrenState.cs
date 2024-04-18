using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.State;
public abstract class ChildrenState
{
    protected PairedElementNode _lightNode;

    public ChildrenState(PairedElementNode lightElementNode)
    {
        _lightNode = lightElementNode;
    }

    public abstract string GetInnerHTML(int depth = 0);
}

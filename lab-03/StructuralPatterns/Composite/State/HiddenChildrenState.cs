using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.State;
public class HiddenChildrenState : ChildrenState
{
    public HiddenChildrenState(PairedElementNode lightElementNode) : base(lightElementNode)
    {
    }

    public override string GetInnerHTML(int depth = 0)
    {
        return $"{_lightNode.GetTabString(depth)}...";
    }
}

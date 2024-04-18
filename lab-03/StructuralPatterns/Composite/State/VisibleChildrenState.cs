using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Composite.State;
public class VisibleChildrenState : ChildrenState
{
    public VisibleChildrenState(PairedElementNode lightElementNode) : base(lightElementNode)
    {
    }

    public override string GetInnerHTML(int depth = 0)
    {
        StringBuilder innerHtml = new StringBuilder();
        _lightNode.Children.ForEach(
            node => innerHtml.Append(_lightNode.GetTabString(depth) + node.GetOuterHTML(depth)));

        return innerHtml.ToString();
    }
}

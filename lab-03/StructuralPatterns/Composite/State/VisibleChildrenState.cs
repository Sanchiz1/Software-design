using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Composite.State;
public class VisibleChildrenState : RenderState
{
    public VisibleChildrenState(LightElementNode lightElementNode) : base(lightElementNode)
    {
    }

    private string TabString(int depth)
        => _lightElementNode.DisplayType == TagDisplayType.Column
        ? "\n" + string.Concat(Enumerable.Repeat("  ", depth))
        : string.Empty;

    public override string GetOuterHTML(int depth = 0)
    {
        return $"{OpeningPart}{GetInnerHTML(depth + 1)}{TabString(depth)}{ClosingPart}";
    }

    public override string GetInnerHTML(int depth = 0)
    {
        StringBuilder innerHtml = new StringBuilder();
        _lightElementNode.Children.ForEach(
            node => innerHtml.Append(TabString(depth) + node.GetOuterHTML(depth)));

        return innerHtml.ToString();
    }
}

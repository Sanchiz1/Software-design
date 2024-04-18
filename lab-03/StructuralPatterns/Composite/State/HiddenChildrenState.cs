using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.State;
public class HiddenChildrenState : RenderState
{
    public HiddenChildrenState(LightElementNode lightElementNode) : base(lightElementNode)
    {
    }

    public override string GetOuterHTML(int depth = 0)
    {
        return $"{OpeningPart}{GetInnerHTML()}{ClosingPart}";
    }

    public override string GetInnerHTML(int depth = 0)
    {
        return _lightElementNode.ClosingType == TagClosingType.Single ?
        string.Empty :
        "...";
    }
}

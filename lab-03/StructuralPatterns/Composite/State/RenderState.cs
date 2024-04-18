using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.State;
public abstract class RenderState
{
    protected LightElementNode _lightElementNode;

    public RenderState(LightElementNode lightElementNode)
    {
        _lightElementNode = lightElementNode;
    }

    protected virtual string ClassesPart
        => _lightElementNode.Classes.Count() > 0 ? $" class=\"{string.Join(' ', _lightElementNode.Classes)}\"" : string.Empty;

    protected virtual string OpeningPart
    => _lightElementNode.ClosingType == TagClosingType.Single ?
        $"<{_lightElementNode.Name}{ClassesPart}" :
        $"<{_lightElementNode.Name}{ClassesPart}>";
    protected virtual string ClosingPart
        => _lightElementNode.ClosingType == TagClosingType.Single ?
        $"/>" :
        $"</{_lightElementNode.Name}>";

    public abstract string GetOuterHTML(int depth = 0);
    public abstract string GetInnerHTML(int depth = 0);
}

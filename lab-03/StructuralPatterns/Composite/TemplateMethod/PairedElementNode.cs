using Composite.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.TemplateMethod;
public class PairedElementNode : LightElementNode
{
    public List<ILightNode> Children { get; } = new List<ILightNode>();
    private ChildrenState _renderState;
    public PairedElementNode(string name, TagDisplayType displayType, List<string> classes, List<ILightNode> children) : base(name, displayType, classes)
    {
        Children = children;
        _renderState = new VisibleChildrenState(this);
    }

    public PairedElementNode AddChildElement(ILightNode node)
    {
        Children.Add(node);

        return this;
    }

    public void ChangeState(ChildrenState state)
    {
        _renderState = state;
    }

    public override string GetInnerHTML(int depth = 0)
    {
        return _renderState.GetInnerHTML(depth);
    }

    protected override string GetOpeningPart()
    {
        return $"<{Name}{GetClassesPart()}>";
    }
    protected override string GetClosingPart()
    {
        return $"</{Name}>";
    }
}

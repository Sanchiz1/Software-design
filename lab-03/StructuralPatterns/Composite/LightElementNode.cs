using Composite;
using Composite.State;
using System.Text;

namespace Composite;
public class LightElementNode : ILightNode
{
    public string Name { get; } = default!;
    public TagDisplayType DisplayType { get; }
    public TagClosingType ClosingType { get; }
    public List<string> Classes { get; } = new List<string>();
    public List<ILightNode> Children { get; } = new List<ILightNode>();
    public List<LightNodeEventListener> EventListeners { get; } = new List<LightNodeEventListener>();
    private RenderState _renderState;


    public LightElementNode(
        string name,
        TagDisplayType displayType,
        TagClosingType closingType,
        List<string> classes,
        List<ILightNode> children)
    {
        if (closingType == TagClosingType.Single && children.Count > 0)
            throw new ArgumentException("Cannot create self-closing tag with children");

        Name = name;
        DisplayType = displayType;
        ClosingType = closingType;
        Classes = classes;
        Children = children;
        _renderState = new VisibleChildrenState(this);
    }

    public void ChangeState(RenderState state)
    {
        _renderState = state;
    }

    public LightElementNode AddChildElement(ILightNode node)
    {
        Children.Add(node);

        return this;
    }

    public string GetOuterHTML(int depth = 0)
    {
        return _renderState.GetOuterHTML(depth);
    }

    public string GetInnerHTML(int depth = 0)
    {
        return _renderState.GetInnerHTML(depth);
    }

    public void AddEventListener(LightNodeEventListener eventListener)
    {
        EventListeners.Add(eventListener);
    }

    public void Notify(string eventName)
    {
        var listeners = EventListeners.Where(listener => listener.EventName == eventName).ToList();

        listeners.ForEach(l => l.Update());
    }
}

public enum TagDisplayType
{
    Row,
    Column,
}

public enum TagClosingType
{
    Single,
    Double
}
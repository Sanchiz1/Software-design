using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.LightNode;
public class LightElementNode : ILightNode
{
    public string Name { get; } = default!;
    public TagDisplayType DisplayType { get; }
    public TagClosingType ClosingType { get; }
    public List<string> Classes { get; } = new List<string>();
    public List<ILightNode> Children { get; } = new List<ILightNode>(); 
    private List<LightNodeEventListener> EventListeners { get; } = new List<LightNodeEventListener>();

    private string TabString(int depth)
        => DisplayType == TagDisplayType.Column
        ? "\n" + string.Concat(Enumerable.Repeat("  ", depth))
        : string.Empty;

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
    }

    public LightElementNode AddChildElement(ILightNode node)
    {
        Children.Add(node);

        return this;
    }

    protected virtual string ClassesPart
        => Classes.Count() > 0 ? $" class=\"{string.Join(' ', Classes)}\"" : string.Empty;

    protected virtual string OpeningPart
        => ClosingType == TagClosingType.Single ? $"<{Name}{ClassesPart}" : $"<{Name}{ClassesPart}>";

    protected virtual string ClosingPart
        => ClosingType == TagClosingType.Single ? $"/>" : $"</{Name}>";

    public string GetOuterHTML(int depth = 0)
    {
        return $"{OpeningPart}{GetInnerHTML(depth + 1)}{TabString(depth)}{ClosingPart}";
    }

    public string GetInnerHTML(int depth = 0)
    {
        StringBuilder innerHtml = new StringBuilder();
        Children.ForEach(
            node => innerHtml.Append(TabString(depth) + node.GetOuterHTML(depth)));

        return innerHtml.ToString();
    }

    public void AddEventListener(LightNodeEventListener eventListener)
    {
        EventListeners.Add(eventListener);
    }

    public void Notify(string eventName)
    {
        var listeners = EventListeners.Where(listener => listener.EventName == eventName).ToList();

        listeners.ForEach(l => l.Update(this));
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

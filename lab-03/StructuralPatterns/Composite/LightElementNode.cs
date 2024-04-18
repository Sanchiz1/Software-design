using Composite;
using Composite.State;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Composite;
public abstract class LightElementNode : ILightNode
{
    public string Name { get; } = default!;
    public TagDisplayType DisplayType { get; }
    public List<string> Classes { get; } = new List<string>();
    public List<LightNodeEventListener> EventListeners { get; } = new List<LightNodeEventListener>();


    public LightElementNode(
        string name,
        TagDisplayType displayType,
        List<string> classes)
    {
        Name = name;
        DisplayType = displayType;
        Classes = classes;
    }



    #region Template method
    public string GetOuterHTML(int depth = 0)
    {
        return $"{GetOpeningPart()}{GetInnerHTML(depth + 1)}{GetTabString(depth)}{GetClosingPart()}";
    }

    protected string GetClassesPart()
        => Classes.Count() > 0 ? $" class=\"{string.Join(' ', Classes)}\"" : string.Empty;

    public string GetTabString(int depth)
        => DisplayType == TagDisplayType.Column
        ? "\n" + string.Concat(Enumerable.Repeat("  ", depth))
        : string.Empty;

    //Mandatory
    protected abstract string GetOpeningPart();

    //Mandatory
    protected abstract string GetClosingPart();

    //Hook
    public virtual string GetInnerHTML(int depth = 0)
    {
        return string.Empty;
    }
    #endregion




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
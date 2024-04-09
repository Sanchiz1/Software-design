using Observer.LightNode;

namespace Observer;
public class LightNodeEventListener
{
    public delegate void LightNodeDelegate(ILightNode lightNode);
    public LightNodeDelegate Action {  get; set; }
    public string EventName { get; set; }

    public LightNodeEventListener(string actionName, LightNodeDelegate lightNodeDelegate)
    {
        this.EventName = actionName;
        this.Action = lightNodeDelegate;
    }

    public void Update(ILightNode subject)
    {
        this.Action.Invoke(subject);
    }
}

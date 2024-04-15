using Observer.LightNode;

namespace Observer;
public class LightNodeEventListener
{
    public Action Action {  get; set; }
    public string EventName { get; set; }

    public LightNodeEventListener(string eventName, Action action)
    {
        this.EventName = eventName;
        this.Action = action;
    }

    public void Update()
    {
        this.Action.Invoke();
    }
}

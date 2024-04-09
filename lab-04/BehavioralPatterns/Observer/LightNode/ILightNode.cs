namespace Observer.LightNode;
public interface ILightNode
{
    public string GetOuterHTML(int depth = 0);
    public string GetInnerHTML(int depth = 1);
    void AddEventListener(LightNodeEventListener lightNodeEventListener);
    void Notify(string eventName);
}

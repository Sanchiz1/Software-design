using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.LightNode;
public class LightTextNode : ILightNode
{
    public string Text { get; } = default!;

    public LightTextNode(string text)
    {
        Text = text;
    }

    public string GetOuterHTML(int depth = 0)
    {
        return GetInnerHTML();
    }

    public string GetInnerHTML(int depth = 0)
    {
        var depthTab = new string('\t', depth);
        return depthTab + Text;
    }
    public void AddEventListener(LightNodeEventListener lightNodeEventListener)
    {
        throw new NotSupportedException("Text nodes do not support event listeners.");
    }

    public void Notify(string eventName)
    {
        throw new NotSupportedException("Text nodes do not support event listeners.");
    }
}

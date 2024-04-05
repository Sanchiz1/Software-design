using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite;
public class LightTextNode : ILightNode
{
    public string Text { get; } = default!;

    public LightTextNode(string text)
    {
        Text = text;
    }

    public string GetOuterHTML(int depth = 0)
    {
        return this.GetInnerHTML();
    }

    public string GetInnerHTML(int depth = 0)
    {
        var depthTab = new string('\t', depth);
        return depthTab + this.Text;
    }
}

using Observer.LightNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

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

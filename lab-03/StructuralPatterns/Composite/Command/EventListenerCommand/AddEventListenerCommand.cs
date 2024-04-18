using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.EventListenerCommand;
public class AddEventListenerCommand : ICommand
{
    private readonly LightElementNode _lightElementNode;
    private readonly LightNodeEventListener _eventListener;

    public AddEventListenerCommand(LightElementNode lightElementNode, string eventName, Action action)
    {
        _lightElementNode = lightElementNode;
        _eventListener = new LightNodeEventListener(eventName, action);
    }

    public void Execute()
    {
        _lightElementNode.AddEventListener(_eventListener);
    }
    public void Undo()
    {
        _lightElementNode.EventListeners.Remove(_eventListener);
    }
}
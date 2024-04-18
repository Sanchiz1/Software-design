using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.ChildCommand;
public class RemoveChildCommand : ICommand
{
    private readonly PairedElementNode _lightElementNode;
    private readonly ILightNode _childNode;

    public RemoveChildCommand(PairedElementNode lightElementNode, ILightNode childNode)
    {
        _lightElementNode = lightElementNode;
        _childNode = childNode;
    }

    public void Execute()
    {
        _lightElementNode.Children.Remove(_childNode);
    }

    public void Undo()
    {
        _lightElementNode.AddChildElement(_childNode);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.ChildCommand;
public class AddChildCommand : ICommand
{
    private readonly LightElementNode _lightElementNode;
    private readonly ILightNode _childNode;

    public AddChildCommand(LightElementNode lightElementNode, ILightNode childNode)
    {
        _lightElementNode = lightElementNode;
        _childNode = childNode;
    }


    public void Execute()
    {
        _lightElementNode.AddChildElement(_childNode);
    }

    public void Undo()
    {
        _lightElementNode.Children.Remove(_childNode);
    }
}

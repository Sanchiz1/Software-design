using Composite.TemplateMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.ChildCommand;
public class ClearChildrenCommand : ICommand
{
    private readonly PairedElementNode _lightElementNode;
    private List<ILightNode> _backup;

    public ClearChildrenCommand(PairedElementNode lightElementNode)
    {
        _lightElementNode = lightElementNode;
    }

    public void Execute()
    {
        SaveBackup(_backup);
        _lightElementNode.Children.Clear();
    }
    public void Undo()
    {
        if (_backup is null) return;

        _lightElementNode.Children.AddRange(_backup);
    }

    public void SaveBackup(List<ILightNode> lightNodes)
    {
        _backup = lightNodes;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.ChildCommand;
public class AddTextCommand : ICommand
{
    private readonly LightElementNode _lightElementNode;
    private readonly string _text;
    private LightTextNode _backup;

    public AddTextCommand(LightElementNode lightElementNode, string text)
    {
        _lightElementNode = lightElementNode;
        _text = text;
    }

    public void Execute()
    {
        var textNode = new LightTextNode(_text);
        SaveBackup(textNode);
        _lightElementNode.AddChildElement(textNode);
    }

    public void Undo()
    {
        if (_backup is null) return;

        _lightElementNode.Children.Remove(_backup);
    }

    public void SaveBackup(LightTextNode textNode) 
    {
        _backup = textNode;
    }
}

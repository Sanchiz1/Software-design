using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.Editor;
public class LightHTMLEditor
{
    private History _history;

    public LightHTMLEditor()
    {
        _history = new History();
    }

    public void Execute(ICommand command)
    {
        _history.Push(command);
        command.Execute();
    }

    public void Undo()
    {
        _history.Pop().Undo();
    }
}

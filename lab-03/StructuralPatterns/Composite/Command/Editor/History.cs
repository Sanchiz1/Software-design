using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Command.Editor;
public class History
{
    public Stack<ICommand> Commands { get; set; } = new Stack<ICommand>();

    public void Push(ICommand command)
    {
        Commands.Push(command);
    }

    public ICommand Pop()
    {
        return Commands.Pop();
    }
}

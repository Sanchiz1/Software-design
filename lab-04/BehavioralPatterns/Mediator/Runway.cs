using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator;
public class Runway
{
    public readonly Guid Id = Guid.NewGuid();
    public bool IsBusy;
    public CommandCentre CommandCentre { get; set; }

    public Runway(CommandCentre commandCentre)
    {
        commandCentre.AssignRunway(this);
    }
    public bool CheckIsActive()
    {
        return this.CommandCentre.IsRunwayActive(this);
    }
}

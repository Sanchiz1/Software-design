namespace Mediator;
public class Aircraft
{
    public readonly Guid Id = Guid.NewGuid();
    public string Name;
    public CommandCentre CommandCentre {  get; set; }
    public bool IsLanded { get; set; }
    public bool IsTakingOff { get; set; } = false;
    public Aircraft(string name, CommandCentre commandCentre)
    {
        this.Name = name;
        commandCentre.AssignAircraft(this);
    }

    public void Land()
    {
        CommandCentre.LandAircraft(this);
    }

    public void TakeOff()
    {
        CommandCentre.TakeOffAircraft(this);
    }
}

namespace Mediator;
public class CommandCentre
{
    private List<Runway> _runways = new List<Runway>();
    private List<Aircraft> _aircrafts = new List<Aircraft>();
    public Dictionary<Aircraft, Runway> _runwaysAircrafts = new Dictionary<Aircraft, Runway>();

    public CommandCentre()
    {
    }

    public void AssignAircraft(Aircraft aircraft)
    {
        aircraft.CommandCentre = this;
        this._aircrafts.Add(aircraft);
    }

    public void AssignRunway(Runway runway)
    {
        runway.CommandCentre = this;
        this._runways.Add(runway);
    }

    public bool IsRunwayActive(Runway runway)
    {
        var airCraft = this._runwaysAircrafts.FirstOrDefault(r => r.Value.Id == runway.Id).Key;

        if (airCraft == null) return false;

        return airCraft.IsTakingOff;
    }

    public void LandAircraft(Aircraft aircraft)
    {
        if (!IsAssignedAircraft(aircraft))
        {
            Console.WriteLine($"Aircraft {aircraft.Id} is not assigned to the command centre, landing refused.");
            return;
        }

        if (aircraft.IsLanded)
        {
            Console.WriteLine($"Aircraft {aircraft.Id} is already landed.");
            return;
        }

        var freeRunway = this._runways.FirstOrDefault(r => !r.IsBusy);

        if(freeRunway == null)
        {
            Console.WriteLine($"No free runways, landing refused.");
            return;
        }

        freeRunway.IsBusy = true;
        aircraft.IsLanded = true;

        this._runwaysAircrafts.Add(aircraft, freeRunway);
        Console.WriteLine($"Aircraft {aircraft.Id} landed on the runway {freeRunway.Id} successfully.");
        Console.WriteLine($"Runway {freeRunway.Id} is busy!");
    }

    public void TakeOffAircraft(Aircraft aircraft)
    {
        if (!IsAssignedAircraft(aircraft))
        {
            Console.WriteLine($"Aircraft {aircraft.Id} is not assigned to the command centre, cannot take off.");
            return;
        }

        if (!aircraft.IsLanded)
        {
            Console.WriteLine($"Aircraft {aircraft.Id} is already took off.");
            return;
        }

        var runway = this._runwaysAircrafts.FirstOrDefault(r => r.Key.Id == aircraft.Id).Value;

        if (runway == null)
        {
            Console.WriteLine($"Aircraft {aircraft.Id} is not landed on any of the runways.");
            return;
        }

        runway.IsBusy = false;
        aircraft.IsLanded = false;

        this._runwaysAircrafts.Remove(aircraft);

        Console.WriteLine($"Aircraft {aircraft.Id} took off from Runway {runway.Id} successfully.");
        Console.WriteLine($"Runway {runway.Id} is free!");
    }

    private bool IsAssignedAircraft(Aircraft aircraft)
    {
        return this._aircrafts.Any(a => a.Id == aircraft.Id);
    }
}

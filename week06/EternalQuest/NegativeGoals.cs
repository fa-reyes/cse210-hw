// Added a NegativeGoal class to track bad habits. When a negative goal is recorded, points are deducted from the total score as a penalty for the behavior.
public class NegativeGoal : Goal 
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points) { }

    public override void RecordEvent() 
    {
        Console.WriteLine("Penalty applied to the total score.");
    }

    public override bool IsComplete()
    {
        return false;
    } 

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- Penalty: {GetPoints()}";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}
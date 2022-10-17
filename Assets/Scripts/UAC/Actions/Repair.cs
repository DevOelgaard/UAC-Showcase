public class Repair: AgentAction
{
    private int consecutiveSelections = 0;
    public Repair()
    {
        Description = "Repairs the unit, and counts the number of consecutive repairs.";
    }

    public override void OnStart(IAiContext context)
    {
        consecutiveSelections = 1;
        RepairUnit(context);
    }

    public override void OnGoing(IAiContext context)
    {
        consecutiveSelections++;
        RepairUnit(context);
    }

    public override void OnEnd(IAiContext context)
    {
        // Resets counter, when not selected
        consecutiveSelections = 0;
    }

    private void RepairUnit(IAiContext context)
    {
        var unit = UacHelper.GetUnitFromAiContext(context);
        unit.Repair(1);
    }
}
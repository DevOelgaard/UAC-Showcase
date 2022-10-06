public class Move: AgentAction
{
    public Move()
    {
        Description = "Moves the unit as much as possible";
    }

    public override void OnStart(IAiContext context)
    {
        var unit = UacHelper.GetUnitFromAiContext(context);
        var map = UacHelper.GetMap();
        InteractionHandler.Move(unit,map);
    }
}
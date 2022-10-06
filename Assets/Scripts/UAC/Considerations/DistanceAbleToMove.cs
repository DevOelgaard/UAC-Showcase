public class DistanceAbleToMove: Consideration
{
    public DistanceAbleToMove()
    {
        Description = "Returns the % of the total distance, which the unit is able to move";
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var map = UacHelper.GetMap();
        return InteractionHandler.GetMoveAbleDistanceNormalized(unit, map);
    }
}
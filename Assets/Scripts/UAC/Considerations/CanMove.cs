public class CanMove: ConsiderationBoolean
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var map = UacHelper.GetMap();
        return InteractionHandler.CanMoveOnMap(unit, map) ? 1 : 0;
    }
}
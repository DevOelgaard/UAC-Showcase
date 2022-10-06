public class TargetInRange: ConsiderationBoolean
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        // Casting context to access the specialized fields
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var distanceToTarget = InteractionHandler.GetDistance(unit, unitContext.Target);
        return unit.attributes.range >= distanceToTarget ? 1 : 0;
    }
}
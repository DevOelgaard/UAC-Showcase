public class PotentialDamagePercent: Consideration
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var potentialDamage = InteractionHandler.GetDamage(unit, unitContext.Target);

        MaxFloat.Value = unitContext.Target.attributes.maxHealth;
        return potentialDamage;
    }
}
﻿public class CanKillTarget: ConsiderationBoolean
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var potentialDamage = InteractionHandler.GetDamage(unit, unitContext.Target);
        return potentialDamage >= unitContext.Target.attributes.health ? 1 : 0;
    }
}
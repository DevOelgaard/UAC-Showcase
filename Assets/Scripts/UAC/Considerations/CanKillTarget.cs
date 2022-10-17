public class CanKillTarget: ConsiderationModifier
{
    public CanKillTarget()
    {
        Description = "Increases the weight of the decision, if the target can be killed";
        HelpText = "The score isn't directly part of the utility calculation instead it alters the decisions weight.";
        AddParameter("Normal weight", 1f);
        AddParameter("Increased weight", 2f);
    }

    // Decides what value should be returned as new weight
    // Notice the difference between this and the standard CalculateBaseScore method
    protected override float CalculateBaseScore(IAiContext context)
    {
        return 1;
    }

    public override float CalculateScore(IAiContext context)
    {
        var normalWeight = ParameterContainer.GetParamFloat("Normal weight").Value;
        var increasedWeight = ParameterContainer.GetParamFloat("Increased weight").Value;
        var unitContext = context as UnitAiContext;
        var unit = UacHelper.GetUnitFromAiContext(unitContext);
        var potentialDamage = InteractionHandler.GetDamage(unit, unitContext.Target);
        return potentialDamage >= unitContext.Target.attributes.health ? increasedWeight : normalWeight;
    }
}
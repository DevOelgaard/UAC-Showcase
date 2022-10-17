public class HealthPercentageOfMax: Consideration
{
    public HealthPercentageOfMax()
    {
        Description = "Returns health as percentage of max health";
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        var unit = UacHelper.GetUnitFromAiContext(context);
        return unit.attributes.health / unit.attributes.maxHealth;
    }
    
    
}
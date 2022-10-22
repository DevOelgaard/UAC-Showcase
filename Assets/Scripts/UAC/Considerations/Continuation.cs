
/// <summary>
/// A ConsiderationModifier alters the weight of the attached decision/bucket.
/// Which directly translates to the prioritization of the given decision/bucket.
/// </summary>
public class Continuation: ConsiderationModifier
{
    private int consecutiveSelections = 0;
    public Continuation()
    {
        Description = "Returns the amount of consecutive selections";
        HelpText = "Remember to select if the consideration is attached to a  decision or a bucket";
        MaxFloat.Value = 10;
        
        AddParameter("Attached To Bucket", false);
        AddParameter("Attached To Decision", true);
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        return -1;
    }

    public override float CalculateScore(IAiContext context)
    {
        var parentAsUtilityContainer = Parent as UtilityContainer;
        var baseWeightOfParent = parentAsUtilityContainer.GetWeight();
        var attachedToBucket = ParameterContainer.GetParamBool("Attached To Bucket");
        var attachedToDecision = ParameterContainer.GetParamBool("Attached To Decision");

        if (attachedToDecision.Value)
        {
            // Checks if the last selected decision is the same as the current evaluated decision
            // Which would indicate a consecutive selection
            consecutiveSelections = context.LastSelectedDecision == context.CurrentEvaluatedDecision
                ? consecutiveSelections++
                : 0;

        } else if (attachedToBucket.Value)
        {
            // Checks if the last selected bucket is the same as the current evaluated bucket
            // Which would indicate a consecutive selection
            consecutiveSelections = context.LastSelectedBucket == context.CurrentEvaluatedBucket
                ? consecutiveSelections++
                : 0;
        }
        else
        {
            consecutiveSelections = 0;
        }
        
        return consecutiveSelections > 0 ? consecutiveSelections : baseWeightOfParent;
    }
}
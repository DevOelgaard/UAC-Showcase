using UnityEngine;

public class Example_ChangeMinMaxDynamically: Consideration
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        var dynamicMinValue = Random.Range(0, 100);
        var dynamicMaxValue = Random.Range(0, 100) + dynamicMinValue;
        MinFloat.Value = dynamicMinValue;
        MaxFloat.Value = dynamicMaxValue;

        var score = Random.Range(dynamicMinValue, dynamicMaxValue);
        return score;
    }
}
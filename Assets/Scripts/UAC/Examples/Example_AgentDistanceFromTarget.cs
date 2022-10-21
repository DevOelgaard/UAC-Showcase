using UnityEngine;

public class Example_AgentDistanceFromTarget: Consideration
{
    public Example_AgentDistanceFromTarget()
    {
        // Set Min and Max value to define the valid range for the calculated base score
        // Can be changed from the UI
        // Can also be changed dynamically
        MinFloat.Value = 10; // Base value = 0;
        MaxFloat.Value = 100; // Base value = 1;
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        var agent = context.Agent as AgentMono; // Cast to agent mono to access MonoBehavior methods
        var target = GameObject.FindWithTag("Target");

        var distance = Vector3.Distance(agent.transform.position, target.transform.position);

        return distance;
    }

    protected override float BaseScoreBelowMinValue()
    {
        // Define what to do when base score is below min
        return 1;
    }

    protected override float BaseScoreAboveMaxValue()
    {
        // Define what to do when base score is above max
        return 0;
    }
}
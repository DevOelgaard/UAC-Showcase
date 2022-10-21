using System;

public class Example_SetContext: Consideration
{
    // Specifies, that this objects sets values in AiContext
    // For this reason the UAI should execute it as soon as possible
    // In order to make the context data available for other considerations and actions
    public override bool IsSetter => true;

    public Example_SetContext()
    {
        Description = "This is an example case for setting AiContext";
        HelpText = "It has no real functionality!";
    }

    protected override float CalculateBaseScore(IAiContext context)
    {
        // This could be a list of coordinates for the agent to move along
        // Since calculating path can be expensive, it is prudent to only do it once
        // and share the path with other considerations that might also need it
        var path = "Some Path";
        
        // KEY_PATH: Is a key (object) chosen by you, which is needed to retrieve the stored data
        // Suggestion: Use enums for keys, to avoid problems with typos and case-mismatching
        // Value: is the data stored
        // The data is shared between the owner and all it's children
        // The owner is set to the parent of this consideration, meaning either a bucket or a decision
        context.SetContext("KEY_PATH",path,Parent);

        throw new NotImplementedException("This is only for example purposes, and shouldn't be used");
    }
}
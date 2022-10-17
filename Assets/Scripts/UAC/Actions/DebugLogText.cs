using UnityEngine;

public class DebugLogText: AgentAction
{
    public DebugLogText()
    {
        Description = "Prints text and unit name";
        AddParameter("Text","");
    }

    public override void OnStart(IAiContext context)
    {
        var unit = UacHelper.GetUnitFromAiContext(context);
        var text = ParameterContainer.GetParamString("Text");
        Debug.Log(unit.name + ": " + text.Value);
    }
}
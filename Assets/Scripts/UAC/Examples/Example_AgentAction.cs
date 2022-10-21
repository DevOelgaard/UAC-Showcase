using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class Example_AgentAction:AgentAction
{
        public override void OnStart(IAiContext context)
        {
                Debug.Log("This is fired the first time the action is selected");
        }

        public override void OnGoing(IAiContext context)
        {
                Debug.Log("This is fired everytime the decision is selected, except the first selection");
                Debug.LogWarning("If this isn't overridden the OnStart method will be fired instead");
        }

        public override void OnEnd(IAiContext context)
        {
                Debug.Log("This is fired when the decision stops being selected");
        }
}
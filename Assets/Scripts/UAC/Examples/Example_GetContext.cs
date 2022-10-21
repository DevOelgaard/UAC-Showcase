public class Example_GetContext: AgentAction
{
    public override void OnStart(IAiContext context)
    {
        var data = context.GetContext<string>("KEY_PATH");
    }
}
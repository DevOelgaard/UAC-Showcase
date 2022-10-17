using System.Collections.Generic;

public class AttackTarget: AgentAction
{
    public AttackTarget()
    {
        Name = "Attack Target";
        Description = "Attacks the selected target";
        HelpText = "A target must have been set in the Context, before this action can be used";
    }

    public override void OnStart(IAiContext context)
    {
        var attacker = UacHelper.GetUnitFromAiContext(context);
        var unitContext = context as UnitAiContext;
        var target = unitContext.Target;
        
        InteractionHandler.Attack(attacker,target);
    }
}
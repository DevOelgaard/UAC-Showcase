using System.Collections.Generic;

public class AttackAllTargets: AgentAction
{
        public override void OnStart(IAiContext context)
        {
                var attacker = UacHelper.GetUnitFromAiContext(context);
                var validTargets = context.GetContext<List<Unit>>(ContextKeys.ValidTargets,this);

                foreach (var validTarget in validTargets)
                {
                        InteractionHandler.Attack(attacker,validTarget);
                }
        }
}
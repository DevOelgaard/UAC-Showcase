using UnityEngine;

public class Example_DecisionMultipleIterations: Decision
{
        protected override float CalculateUtility(IAiContext context)
        {
                GameObject bestTarget = null;
                var highestUtility = float.MinValue;
                var potentialTargets = GameObject.FindGameObjectsWithTag("Enemy");

                // Evaluating each potential target
                foreach (var potentialTarget in potentialTargets)
                {
                        context.SetContext("KEY_TARGET",potentialTarget,this);

                        var utility = Evaluate(context);
                        if (utility > highestUtility)
                        {
                                bestTarget = potentialTarget;
                                highestUtility = utility;
                        }
                }
                
                // Storing the best target in context, to be used by associated actions
                // Ie: Attack(Target)
                context.SetContext("KEY_TARGET",bestTarget,this);
                return highestUtility;
        }
}
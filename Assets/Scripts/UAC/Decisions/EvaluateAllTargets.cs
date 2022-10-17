using System.Collections.Generic;
using UnityEngine;

public class EvaluateAllTargets: Decision
{
    private GameMap gameMap;

    private GameMap GameMap
    {
        get
        {
            if (gameMap == null)
            {
                gameMap = GameObject.Find("GameMap").GetComponent<GameMap>();
            }

            return gameMap;
        }
    }
    public EvaluateAllTargets()
    {
        AddParameter("Evaluate Defenders", true);
        AddParameter("Evaluate Attackers", false);
        Name = "Evaluate All Targets";
        Description = "Evaluates all defensive structures and/or attacking units, based on the parameter selection. Fails if no targets are found";
    }

    protected override float CalculateUtility(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        var targets = new List<Unit>();

        var evaluateDefenders = ParameterContainer.GetParamBool("Evaluate Defenders");
        var evaluateAttackers = ParameterContainer.GetParamBool("Evaluate Attackers");

        // Adding defensive structures if parameter is set
        if (evaluateDefenders.Value)
        {
            foreach (var spawnPoint in GameMap.structureSpawnPoints)
            {
                targets.AddRange(spawnPoint.UnitsSpawned);
            }
        }

        // Adding attackers if parameter is set
        if (evaluateAttackers.Value)
        {
            foreach (var spawnPoint in GameMap.unitSpawnPoints)
            {
                targets.AddRange(spawnPoint.UnitsSpawned);
            }
        }
        
        var highestUtility = float.MinValue;
        Unit highestValuedTarget = default;

        // Calculates Utility for each potential target;
        foreach (var target in targets)
        {
            // Setting current target in context, for it to be evaluated
            unitContext.Target = target;
            var utility = context.UtilityScorer.CalculateUtility(Considerations.Values, unitContext);
            if (utility > highestUtility)
            {
                highestUtility = utility;
                highestValuedTarget = target;
            }
        }
        
        // Setting the highest valued target in unitContext, for it to be used by AgentActions if decisions is selected
        unitContext.Target = highestValuedTarget;
        return highestUtility;
    }
}
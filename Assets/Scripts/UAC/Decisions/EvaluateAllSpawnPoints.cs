using System.Collections.Generic;

public class EvaluateAllSpawnPoints: Decision
{
        public EvaluateAllSpawnPoints()
        {
                AddParameter("Is Defender", true);
                Description =
                        "Runs all attached considerations on each Spawn Point. The highest score is returned and " +
                        "the highest scoring spawn point is stored in the UnitAiContext";
                HelpText = "This sets UnitAiContext.SelectedSpawnPoint, which can be used by the decisions " +
                           "child considerations and actions";
        }

        
        protected override float CalculateUtility(IAiContext context)
        {
                var gameMap = UacHelper.GetMap();
                var unitContext = context as UnitAiContext;
                List<SpawnPoint> spawnPointsToEvaluate;
                spawnPointsToEvaluate = 
                        ParameterContainer.GetParamBool("Is Defender").Value ? 
                                gameMap.structureSpawnPoints : gameMap.unitSpawnPoints;
                var highestUtility = float.MinValue;
                foreach (var spawnPoint in spawnPointsToEvaluate)
                {
                        unitContext.SpawnPointToEvaluate = spawnPoint;
                        var utility = base.CalculateUtility(unitContext);
                        if (utility > highestUtility)
                        {
                                unitContext.SelectedSpawnPoint = spawnPoint;
                                highestUtility = utility;
                        }
                }

                return highestUtility;
        }
}
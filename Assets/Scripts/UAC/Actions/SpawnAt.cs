using System;
using UnityEngine;

public class SpawnAt: AgentAction
{
        public SpawnAt()
        {
                HelpText = "A spawn point must be set in the AiContext " +
                              "A Unit type must spawning must either be selected in parameters or in code";
                AddParameter("Use Parameter Spawn Type", true);
                AddParameter("Unit Type Spawn",UnitType.Brute);
        }

        public override void OnStart(IAiContext context)
        {
                var unitAiContext = context as UnitAiContext;
                UnitType unitToSpawn;
                if (ParameterContainer.GetParamBool("Use Parameter Spawn Type").Value)
                {
                        var enumParam = ParameterContainer.GetParamEnum("Unit Type Spawn");
                        unitToSpawn = (UnitType)enumParam.Value;
                }
                else
                {
                        unitToSpawn = unitAiContext.UnityTypeToSpawn;
                }
                unitAiContext.SelectedSpawnPoint.SpawnUnit(unitToSpawn);
        }
}
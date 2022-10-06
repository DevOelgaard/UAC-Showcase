using UnityEngine;

public class UacHelper
{
       /// <summary>
       /// This only works because Unit derives from AgentMono.
       /// </summary>
       /// <param name="context"></param>
       /// <returns></returns>
       public static Unit GetUnitFromAiContext(IAiContext context)
       {
              return context.Agent as Unit;
       }

       /// <summary>
       /// Use this in cases where Unit doesn't derive from AgentMono, but instead has agent mono attached as a component in the inspector
       /// </summary>
       /// <param name="context"></param>
       /// <returns></returns>
       public static Unit GetUnitFromAiContextWhereAgentMonoIsAttached(IAiContext context)
       {
              var agent = context.Agent as AgentMono;
              var unit = agent.GetComponent<Unit>();
              return unit;
       }

       /// <summary>
       /// This is extremely inefficient, but used to reduce development time. The Map, should be stored in memory after being found the first time.
       /// </summary>
       /// <returns></returns>
       public static GameMap GetMap()
       {
              return GameObject.Find("GameMap").GetComponent<GameMap>();
       }
}
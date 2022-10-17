using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnHandler
{
      public int TurnCount { get; private set; }
      private static TurnHandler _instance;

      public static TurnHandler Instance => _instance ??= new TurnHandler();

      private TurnHandler()
      {
            turnOrder = new Queue<Unit>();
            TurnCount = 0;
      }

      private Queue<Unit> turnOrder;
      private Unit activeUnit;

      public void AddUnitToTurnOrder(Unit unit)
      {
            turnOrder.Enqueue(unit);
      }

      public void RemoveUnitFromTurnOrder(Unit unit)
      {
            turnOrder = new Queue<Unit>(turnOrder.Where(u => u != unit));
      }

      public void TakeNextTurn()
      {

            Debug.Log("---! Turn: " + TurnCount + " !---");
            var currentTurn = TurnCount;
            TurnCount++;
            
            if (activeUnit != null)
            {
                  activeUnit.Animator.StopAnimation();
                  AddUnitToTurnOrder(activeUnit);
            }
            
            if (turnOrder.Count == 0)
            {
                  return;
            }
            activeUnit = turnOrder.Dequeue();
            var metaData = new TickMetaData
            {
                  TickCount = currentTurn
            };
            activeUnit.ActivateNextAction(metaData);
            activeUnit.Animator.StartAnimation();
            Debug.Log("Unit: " + activeUnit.name + " finished it's turn in: " + metaData.ExecutionTimeInMicroSeconds+"ms.");
            
            
      }
}
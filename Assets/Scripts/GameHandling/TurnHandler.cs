using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TurnHandler
{
      private TextMeshProUGUI turnCounterUi;

      private TextMeshProUGUI TurnCounterUi
      {
            get
            {
                  if (turnCounterUi == null)
                  {
                        turnCounterUi = GameObject
                              .Find("TurnCounter")
                              .GetComponent<TextMeshProUGUI>();
                  }

                  return turnCounterUi;
            }
      }
      
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
            HighlightNextUnit();
      }

      public void RemoveUnitFromTurnOrder(Unit unit)
      {
            turnOrder = new Queue<Unit>(turnOrder.Where(u => u != unit));
            HighlightNextUnit();
      }

      private void HighlightNextUnit()
      {
            if (activeUnit != null)
            {
                  activeUnit.MarkForNextTurn(false);

            }
            // Very inefficient
            foreach (var unit in turnOrder)
            {
                 unit.MarkForNextTurn(false);
            }

            if (turnOrder.Count == 0) return;
            var nextUnit = turnOrder.Peek();
            nextUnit.MarkForNextTurn(true);
      }

      public void TakeNextTurn()
      {
            Debug.Log("---! Turn: " + TurnCount + " !---");
            var currentTurn = TurnCount;
            TurnCount++;
            TurnCounterUi.text = TurnCount.ToString();
            
            if (activeUnit != null)
            {
                  activeUnit.Animator.StopAnimation();
                  AddUnitToTurnOrder(activeUnit);
            }
            
            if (turnOrder.Count == 0)
            {
                  // HighlightNextUnit();
                  return;
            }
            activeUnit = turnOrder.Dequeue();
            var metaData = new TickMetaData
            {
                  TickCount = currentTurn
            };
            activeUnit.ActivateNextAction(metaData);
            activeUnit.Animator.StartAnimation();
            Debug.Log("Unit: " + activeUnit.name + " finished it's turn in: " + metaData.ExecutionTimeInMicroSeconds/1000+"ms.");
            HighlightNextUnit();
      }
}
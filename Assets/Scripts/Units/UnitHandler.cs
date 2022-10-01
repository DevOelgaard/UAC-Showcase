using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Object = UnityEngine.Object;

public class UnitHandler
{
     #region Singleton

     private static UnitHandler _instance;
     public static UnitHandler Instance => _instance ??= new UnitHandler();

     private UnitHandler()
     {
          units = new List<Unit>();
     }
     #endregion
     private List<Unit> units;
     private readonly Dictionary<Unit, IDisposable> unitSubscriptions = new Dictionary<Unit, IDisposable>();

     public void AddUnit(Unit unit)
     {
          units.Add(unit);
          var unitSub = unit.HasDied.Subscribe(HandleUnitDied);
          unitSubscriptions.Add(unit,unitSub);
     }

     private void HandleUnitDied(Unit unit)
     {
          unitSubscriptions[unit].Dispose();
          units.Remove(unit);
          TurnHandler.Instance.RemoveUnitFromTurnOrder(unit);
          Object.Destroy(unit);
     }

     ~UnitHandler()
     {
          foreach (var keyValuePair in unitSubscriptions)
          {
               keyValuePair.Value.Dispose();
          }
     }
     
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SpawnPoint: MonoBehaviour
{
    private Dictionary<Unit, IDisposable> unitSubscriptions = new Dictionary<Unit, IDisposable>();
    public bool isUnitSpawn = true;
    public List<Unit> UnitsSpawned { get; private set; }= new List<Unit>();
    public int maxAllowedSpawns = 4;


    public void SpawnUnit(UnitType unitType)
    {
        if (CanSpawn())
        {
            var unit = Instantiater.InstantiateUnit(this, unitType);
            UnitsSpawned.Add(unit);
            var sub = unit.HasDied.Subscribe(HandleUnitDied);
            unitSubscriptions.Add(unit,sub);
            Debug.Log(name + " Spawned: " + unit.name + ". Usage: " + UnitsSpawned.Count + "/" + maxAllowedSpawns);
        }
        else
        {
            Debug.LogError("Can't spawn Unit: " + unitType);
        }
    }

    private void HandleUnitDied(Unit unit)
    {
        RemoveUnit(unit);
    }

    private void Start()
    {
        UnitsSpawned = new List<Unit>();
    }

    public bool CanSpawn()
    {
        if (isUnitSpawn)
        {
            return UnitsSpawned.Count < maxAllowedSpawns;
        }
        else
        {
            return UnitsSpawned.Count == 0;
        }
    }

    public void RemoveUnit(Unit unit)
    {
        UnitsSpawned.Remove(unit);
        RemoveSubscription(unit);
    }

    private void RemoveSubscription(Unit unit)
    {
        if (unitSubscriptions.ContainsKey(unit))
        {
            unitSubscriptions[unit].Dispose();
            unitSubscriptions.Remove(unit);
        }
    }

    private Instantiater instantiater;

    private Instantiater Instantiater
    {
        get
        {
            if (instantiater == null)
            {
                instantiater = GameObject.Find("Instantiater").GetComponent<Instantiater>();
            }

            return instantiater;
        }
    }

    private void OnDestroy()
    {
        foreach (var unitSubscription in unitSubscriptions)
        {
            unitSubscription.Value.Dispose();
        }
    }
}
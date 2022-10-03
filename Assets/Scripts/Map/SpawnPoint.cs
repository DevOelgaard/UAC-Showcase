using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPoint: MonoBehaviour
{
    public bool isUnitSpawn = true;
    private List<Unit> unitsSpawned = new List<Unit>();
    public int maxAllowedSpawns = 4;


    public void SpawnUnit(UnitType unitType)
    {
        if (CanSpawn())
        {
            var unit = Instantiater.InstantiateUnit(this, unitType);
            unitsSpawned.Add(unit);
            Debug.Log(name + " Spawned: " + unit.name + ". Usage: " + unitsSpawned.Count + "/" + maxAllowedSpawns);
        }
        else
        {
            Debug.LogError("Can't spawn Unit: " + unitType);
        }
    }

    private void Start()
    {
        unitsSpawned = new List<Unit>();
    }

    public bool CanSpawn()
    {
        if (isUnitSpawn)
        {
            return unitsSpawned.Count < maxAllowedSpawns;
        }
        else
        {
            return unitsSpawned.Count == 0;
        }
    }

    public void RemoveUnit(Unit unit)
    {
        unitsSpawned.Remove(unit);
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
}
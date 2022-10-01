using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnPoint: MonoBehaviour
{
    public bool isUnitSpawn = true;
    private List<Unit> unitsSpawned = new List<Unit>();
    public int maxAllowedSpawns = 4;

    public void SpawnUnit(Unit unit)
    {
        if (CanSpawn())
        {
            unitsSpawned.Add(unit);
        }
        else
        {
            Debug.LogError("Can't spawn Unit: " + unit.name);
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
}
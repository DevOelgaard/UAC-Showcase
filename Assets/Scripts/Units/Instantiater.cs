using System;
using UnityEngine;

public class Instantiater: MonoBehaviour
{
    public Unit tank;
    public Unit humvee;
    public Unit brute;
    public Unit missileLauncher;
    public Unit turret;
    public Unit castle;

    public Unit InstantiateUnit(SpawnPoint spawnPoint, UnitType unitType)
    {
        var unitToSpawn = unitType switch
        {
            UnitType.Tank => tank,
            UnitType.Humvee => humvee,
            UnitType.Brute => brute,
            UnitType.MissileLauncher => missileLauncher,
            UnitType.Turret => turret,
            UnitType.Castle => castle,
            _ => throw new ArgumentOutOfRangeException(nameof(unitType), unitType, null)
        };

        var spawnPointTransform = spawnPoint.transform;
        var unit = Instantiate(unitToSpawn, spawnPointTransform.position, Quaternion.identity);
        unit.transform.SetParent(spawnPointTransform);
        // Lazy quickfix to a sprite, that should have been flipped
        if (unitType == UnitType.Brute)
        {
            var rotation = unit.transform.rotation;
            rotation.y = 180;
            unit.transform.rotation = rotation;
        }
        return unit;
    }
}
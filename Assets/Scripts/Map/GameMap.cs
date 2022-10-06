using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Serialization;

public class GameMap : MonoBehaviour
{
     public float LeftUnitBoundary { get; private set; } = -10f;
     public float RightUnitBoundary { get; private set; } = 5f;
     public List<SpawnPoint> unitSpawnPoints = new List<SpawnPoint>();
     public List<SpawnPoint> structureSpawnPoints = new List<SpawnPoint>();
     
}
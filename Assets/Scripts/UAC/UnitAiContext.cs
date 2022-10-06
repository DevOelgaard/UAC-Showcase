using System.Collections.Generic;

/// <summary>
/// A base AiContext can be used, but by using this, specific fields can be added like Targets, which improves performance.
/// </summary>
public class UnitAiContext: AiContext
{
    public List<Unit> Targets = new List<Unit>();
    public Unit Target;
    public List<SpawnPoint> OwnSpawnPoints = new List<SpawnPoint>();
    public List<SpawnPoint> EnemySpawnPoints = new List<SpawnPoint>();
    public SpawnPoint SpawnPointToEvaluate;
    public SpawnPoint SelectedSpawnPoint;
    public UnitType UnityTypeToSpawn;

}
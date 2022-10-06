public class CanSpawnOnAnySpawnPoint: ConsiderationBoolean
{
    protected override float CalculateBaseScore(IAiContext context)
    {
        var unitContext = context as UnitAiContext;
        foreach (var spawnPoint in unitContext.OwnSpawnPoints)
        {
            if (spawnPoint.CanSpawn() == true) return 1;
        }

        // No spawnPoints with available space
        return 0;
    }
}
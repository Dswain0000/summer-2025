using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Tooltip("Prefab to spawn. Must not be a scene instance.")]
    public GameObject enemyPrefab;

    [Tooltip("Spawn points to choose from.")]
    public Transform[] spawnPoints;

    [Tooltip("Time between spawns in seconds.")]
    public float spawnInterval = 5f;

    void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned!");
            return;
        }

        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points assigned!");
            return;
        }

        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

   void SpawnEnemy()
{
    if (enemyPrefab == null)
    {
        Debug.LogWarning("Enemy prefab is null or destroyed – stopping spawner.");
        CancelInvoke(nameof(SpawnEnemy));
        return;
    }

    if (spawnPoints == null || spawnPoints.Length == 0)
    {
        Debug.LogWarning("No spawn points! Stopping spawner.");
        CancelInvoke(nameof(SpawnEnemy));
        return;
    }

    foreach (var sp in spawnPoints)
    {
        if (sp == null)
        {
            Debug.LogWarning("Found a null spawn point—skipping.");
            continue;
        }

        Instantiate(enemyPrefab, sp.position, sp.rotation);
    }
}


}

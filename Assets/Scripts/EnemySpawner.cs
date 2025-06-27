using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;       // © •¡”‚Ì“GƒvƒŒƒnƒu‚ğ“o˜^
    [SerializeField] private LineRenderer[] routeLines;
    [SerializeField] private float spawnInterval = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // ƒ‰ƒ“ƒ_ƒ€‚È“G‚Æƒ‹[ƒg‚ğ‘I‚Ô
        int prefabIndex = Random.Range(0, enemyPrefabs.Length);
        int routeIndex = Random.Range(0, routeLines.Length);

        GameObject selectedPrefab = enemyPrefabs[prefabIndex];
        LineRenderer selectedRoute = routeLines[routeIndex];

        GameObject enemy = Instantiate(selectedPrefab);

        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.SetPath(selectedRoute);
    }
}

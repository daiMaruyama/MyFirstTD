using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;       // ← 複数の敵プレハブを登録
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
        // ランダムな敵とルートを選ぶ
        int prefabIndex = Random.Range(0, enemyPrefabs.Length);
        int routeIndex = Random.Range(0, routeLines.Length);

        GameObject selectedPrefab = enemyPrefabs[prefabIndex];
        LineRenderer selectedRoute = routeLines[routeIndex];

        GameObject enemy = Instantiate(selectedPrefab);

        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.SetPath(selectedRoute);
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private LineRenderer path;
    private int currentIndex = 0;
    private Vector3[] pathPoints;

    [SerializeField] private float moveSpeed = 2f;

    // 血管ルートをセットする関数
    public void SetPath(LineRenderer line)
    {
        path = line;
        int pointsCount = path.positionCount;
        pathPoints = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            pathPoints[i] = path.GetPosition(i);
        }
        // 初期位置をルートの最初に設定
        transform.position = pathPoints[0];
        currentIndex = 0;
    }

    void Update()
    {
        if (pathPoints == null || currentIndex >= pathPoints.Length) return;

        Vector3 target = pathPoints[currentIndex];
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            currentIndex++;
            if (currentIndex >= pathPoints.Length)
            {
                // 到達した時の処理（例: タワーにダメージなど）
                Destroy(gameObject);
            }
        }
    }
}

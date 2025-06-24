using UnityEngine;

public class Line1 : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    [SerializeField] float _speed = 2f;
    private int index = 0;

    void Start()
    {
        transform.position = _lineRenderer.GetPosition(0);
    }

    void Update()
    {
        // ゴールチェック（次がない）
        if (index + 1 >= _lineRenderer.positionCount)
        {
            return;
        }

        Vector3 nextGoal = _lineRenderer.GetPosition(index + 1);
        Vector3 direction = (nextGoal - transform.position).normalized;

        // 移動
        transform.position += direction * _speed * Time.deltaTime;

        // 距離が近づいたら次の点へ
        if (Vector3.Distance(transform.position, nextGoal) < 0.05f)
        {
            index++;
        }
    }
}
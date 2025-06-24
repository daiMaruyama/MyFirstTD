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
        // �S�[���`�F�b�N�i�����Ȃ��j
        if (index + 1 >= _lineRenderer.positionCount)
        {
            return;
        }

        Vector3 nextGoal = _lineRenderer.GetPosition(index + 1);
        Vector3 direction = (nextGoal - transform.position).normalized;

        // �ړ�
        transform.position += direction * _speed * Time.deltaTime;

        // �������߂Â����玟�̓_��
        if (Vector3.Distance(transform.position, nextGoal) < 0.05f)
        {
            index++;
        }
    }
}
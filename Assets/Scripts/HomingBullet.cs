using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public BulletType bulletType = BulletType.Blue;  // ホーミング弾はBlue
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 200f;
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private string enemyTag = "Enemy";

    private Transform target;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        FindClosestEnemy();
    }

    private void Update()
    {
        if (target == null)
        {
            FindClosestEnemy();
            return;
        }

        Vector2 direction = (Vector2)(target.position - transform.position).normalized;
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        transform.Rotate(0, 0, -rotateAmount * rotateSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(enemyTag) && other.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(bulletType);
            Destroy(gameObject);
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDistance = Mathf.Infinity;
        Transform closest = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = enemy.transform;
            }
        }

        target = closest;
    }
}

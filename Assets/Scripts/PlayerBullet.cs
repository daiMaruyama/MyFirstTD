using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public BulletType bulletType = BulletType.White;  // ← 追加：弾の種類を設定可能に

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 3f;
    [SerializeField] private int bulletDamage = 1;

    private void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * speed;
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(bulletType);  // BulletTypeを渡す
            Destroy(gameObject);
        }
    }
}

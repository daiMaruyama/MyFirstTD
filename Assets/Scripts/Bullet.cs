using UnityEngine;


public class Bullet : MonoBehaviour
{
    public BulletType bulletType;  // 弾の種類をInspectorで選べるように
    public float bulletDamage = 1f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletType);
            }
            Destroy(gameObject);  // 当たったら弾は消える
        }
    }
}

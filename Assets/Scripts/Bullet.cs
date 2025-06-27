using UnityEngine;


public class Bullet : MonoBehaviour
{
    public BulletType bulletType;  // �e�̎�ނ�Inspector�őI�ׂ�悤��
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
            Destroy(gameObject);  // ����������e�͏�����
        }
    }
}

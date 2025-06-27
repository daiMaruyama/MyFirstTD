using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;   // 弾プレハブ（インデックス順に）
    [SerializeField] private float[] fireCooldowns;        // 弾ごとの発射間隔
    [SerializeField] private Sprite[] playerSprites;       // プレイヤーの見た目（弾に対応）

    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioClip shootSE;
    [SerializeField] private AudioSource audioSource;

    private SpriteRenderer spriteRenderer; // プレイヤー自身の見た目を変える
    private float lastFireTime = 0f;
    private int currentBulletIndex = 0;

    private void Start()
    {
        lastFireTime = -fireCooldowns[0];
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePlayerSprite();  // 初期見た目反映
    }

    void Update()
    {
        // 左クリック：射撃
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastFireTime >= fireCooldowns[currentBulletIndex])
            {
                Shoot();
                lastFireTime = Time.time;
            }
        }

        // 右クリック：弾と見た目を切り替え
        if (Input.GetMouseButtonDown(1))
        {
            currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;
            UpdatePlayerSprite();
            Debug.Log("弾を切り替えた: " + bulletPrefabs[currentBulletIndex].name);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefabs[currentBulletIndex], firePoint.position, firePoint.rotation);

        if (audioSource != null && shootSE != null)
        {
            audioSource.PlayOneShot(shootSE);
        }
    }

    //プレイヤーのスプライト変更処理
    void UpdatePlayerSprite()
    {
        if (spriteRenderer != null && playerSprites.Length > currentBulletIndex)
        {
            spriteRenderer.sprite = playerSprites[currentBulletIndex];
        }
    }
}

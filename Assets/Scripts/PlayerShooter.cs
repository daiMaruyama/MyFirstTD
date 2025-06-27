using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;   // �e�v���n�u�i�C���f�b�N�X���Ɂj
    [SerializeField] private float[] fireCooldowns;        // �e���Ƃ̔��ˊԊu
    [SerializeField] private Sprite[] playerSprites;       // �v���C���[�̌����ځi�e�ɑΉ��j

    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioClip shootSE;
    [SerializeField] private AudioSource audioSource;

    private SpriteRenderer spriteRenderer; // �v���C���[���g�̌����ڂ�ς���
    private float lastFireTime = 0f;
    private int currentBulletIndex = 0;

    private void Start()
    {
        lastFireTime = -fireCooldowns[0];
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdatePlayerSprite();  // ���������ڔ��f
    }

    void Update()
    {
        // ���N���b�N�F�ˌ�
        if (Input.GetMouseButton(0))
        {
            if (Time.time - lastFireTime >= fireCooldowns[currentBulletIndex])
            {
                Shoot();
                lastFireTime = Time.time;
            }
        }

        // �E�N���b�N�F�e�ƌ����ڂ�؂�ւ�
        if (Input.GetMouseButtonDown(1))
        {
            currentBulletIndex = (currentBulletIndex + 1) % bulletPrefabs.Length;
            UpdatePlayerSprite();
            Debug.Log("�e��؂�ւ���: " + bulletPrefabs[currentBulletIndex].name);
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

    //�v���C���[�̃X�v���C�g�ύX����
    void UpdatePlayerSprite()
    {
        if (spriteRenderer != null && playerSprites.Length > currentBulletIndex)
        {
            spriteRenderer.sprite = playerSprites[currentBulletIndex];
        }
    }
}

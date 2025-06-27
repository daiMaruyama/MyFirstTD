using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // ��]���Ȃ��悤�Œ�
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // ��=-1�A�E=1�A������=0
    }

    void FixedUpdate()
    {
        if (moveInput == 0)
        {
            // ���͂��Ȃ���Ί���Ȃ��悤�Ɏ~�߂�
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            // �ʏ�ړ�
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // �v���C���[�̌����𔽓]�i�K�v�Ȃ�j
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}

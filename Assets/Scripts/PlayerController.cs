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
        rb.freezeRotation = true; // 回転しないよう固定
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // 左=-1、右=1、無入力=0
    }

    void FixedUpdate()
    {
        if (moveInput == 0)
        {
            // 入力がなければ滑らないように止める
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else
        {
            // 通常移動
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

            // プレイヤーの向きを反転（必要なら）
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Sprite downSprite;   // หันลง
    public Sprite upSprite;     // หันขึ้น
    public Sprite leftSprite;   // หันซ้าย
    public Sprite rightSprite;  // หันขวา

    Rigidbody2D rb;
    SpriteRenderer sr;
    Vector2 input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // รับปุ่มกด
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input = input.normalized;

        // 👇 เปลี่ยนรูปตามทิศทางที่กด
        if (input.x > 0.1f)
        {
            sr.sprite = rightSprite;
        }
        else if (input.x < -0.1f)
        {
            sr.sprite = leftSprite;
        }
        else if (input.y > 0.1f)
        {
            sr.sprite = upSprite;
        }
        else if (input.y < -0.1f)
        {
            sr.sprite = downSprite;
        }
        // ถ้าไม่กดอะไรเลย จะยังใช้รูปทิศสุดท้ายที่กดอยู่
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * moveSpeed;
    }
}

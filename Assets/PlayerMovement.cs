using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    public float shrinkRate = 0.5f;
    public float minSize = 0.1f;

    Rigidbody2D rb;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal movement (A/D or Left/Right)
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Shrink();
        }
    }

    void Shrink()
    {
        Vector3 scale = transform.localScale;
        scale -= Vector3.one * shrinkRate * Time.deltaTime;

        // Clamp so it never goes negative
        scale.x = Mathf.Max(scale.x, minSize);
        scale.y = Mathf.Max(scale.y, minSize);

        transform.localScale = scale;

        // Optional: game over check
        if (scale.x <= minSize)
        {
            Debug.Log("Slime died");
            // Time.timeScale = 0f; // uncomment later if you want freeze
        }
    }
}

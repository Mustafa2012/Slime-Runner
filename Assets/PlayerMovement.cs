using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    private Animator animator;
    private SpriteRenderer spriteRenderer;   

    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
    }

    void Update()
    {
        
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        
        if (moveInput > 0.01f)
        {
            spriteRenderer.flipX = false; 
        }
        else if (moveInput < -0.01f)
        {
            spriteRenderer.flipX = true; 
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerHealth.TakeDamage(20f * Time.deltaTime);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }
    }
}

using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalInput;

    [Header("Hareket Ayarlari")]
    private float moveSpeed = 8f;
    private float jumpForce = 6f;

    [Header("Zemin Kontrolu")]
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
         
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

  
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
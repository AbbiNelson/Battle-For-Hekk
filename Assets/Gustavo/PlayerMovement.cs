using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    public float moveSpeed = 9f;
    public float jumpPower = 7f;
    bool isJumping = false;
    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public int facingDirection = 1;







    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (horizontalInput > .1f && facingDirection < 0)
        {
            Flip();
        }
        else if (horizontalInput < -.1f && facingDirection > 0)
        {
            Flip();
        }

        void Flip()
        {
            facingDirection *= -1;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }


        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            isJumping = true;
        }
        

       
      

        
    }

    
    private void FixedUpdate()
    {
        
        
        
          rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
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
    

    
   

   

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        

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
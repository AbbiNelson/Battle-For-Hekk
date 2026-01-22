using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;

    private Vector2 moveInput;
    private bool doubleJumpAvailable = true;
    private bool isGrounded;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float airControl = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            doubleJumpAvailable = true; // reset double jump when grounded
            rb.linearVelocityX = moveInput.x * moveSpeed; // grounded means instant horizontal control
        }
        else
        {
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, moveInput.x * moveSpeed, airControl * Time.deltaTime); // reduced air control with smoothing
        }

    }

    private bool IsGrounded()
    {
        // Implement ground check logic here
        Collider2D[] bottomCollisions = Physics2D.OverlapCircleAll(transform.position + Vector3.down, 0.1f);

        foreach (var collision in bottomCollisions)
        {
            if (collision != coll)
            {
                return true;
            }
        }

        return false;
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    // check if the collided object has the "Ground" or "Player" tag
    //    if (other.collider.CompareTag("Ground") || other.collider.CompareTag("Player"))
    //    {
    //        isGrounded = true;
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    // Only set isGrounded to false if the player leaves the actual ground
    //    // This prevents an issue where leaving another player makes you unable to jump on the ground
    //    if (other.collider.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && doubleJumpAvailable)
        {
            rb.linearVelocityY = jumpForce;
            rb.linearVelocityX = moveInput.x * moveSpeed; // instant horizontal control

            if (!IsGrounded())
            {
                doubleJumpAvailable = false; // Consume double jump
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        print("guacalmolle");
    }
}

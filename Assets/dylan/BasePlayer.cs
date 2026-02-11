using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class Cooldown
{
    [SerializeField] private float CooldownTime;
    private float lastUsedTime;

    // constructor (initialization)
    public Cooldown(float cooldownTime)
    {
        CooldownTime = cooldownTime;
        lastUsedTime = -cooldownTime; // initialize to allow immediate use
    }

    public bool IsReady()
    {
        return Time.time >= lastUsedTime + CooldownTime;
    }

    public void Trigger()
    {
        lastUsedTime = Time.time;
    }
}

public class BasePlayer : MonoBehaviour
{
    public int facingDirection = 1;

    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    private ParticleManager particleManager;

    private Vector2 moveInput;
    private bool doubleJumpAvailable = true;

    private float moveSpeed = 5f;
    private float jumpForce = 10f;
    private float dashForce = 15f;
    private float dashDuration = 0.2f; // in seconds
    private Cooldown dashCooldown = new Cooldown(5f); // 2 seconds cooldown
    private float airControl = 3f;

    // methods to assign values to the player attributes
    public void AssignValues(float moveSpeed, float jumpForce, float dashForce, float dashDuration, Cooldown dashCooldown, float airControl)
    {
        this.moveSpeed = moveSpeed;
        this.jumpForce = jumpForce;
        this.dashForce = dashForce;
        this.dashDuration = dashDuration;
        this.dashCooldown = dashCooldown;
        this.airControl = airControl;
    }

    public void AssignAnimation(RuntimeAnimatorController controller)
    {
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = controller;
    }

    public void AssignColor(Material playerRecolor)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.material = playerRecolor;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        particleManager = GetComponent<ParticleManager>();
    }

    void Update()
    {
        if (rb.gravityScale == 0)
        {
            return; // skip movement control during dash
        }

        if (IsGrounded())
        {
            doubleJumpAvailable = true; // reset double jump when grounded
            rb.linearVelocityX = moveInput.x * moveSpeed; // grounded means instant horizontal control
        }
        else
        {
            rb.linearVelocityX = Mathf.Lerp(rb.linearVelocityX, moveInput.x * moveSpeed, airControl * Time.deltaTime); // reduced air control with smoothing
        }

        if (moveInput.x > .1f && facingDirection < 0)
        {
            Flip();
        }
        else if (moveInput.x < -.1f && facingDirection > 0)
        {
            Flip();
        }

        void Flip()
        {
            facingDirection *= -1;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

            if (transform.childCount > 0 && transform.GetChild(0).TryGetComponent(out SpriteRenderer sr))
            {
                if (facingDirection < 0)
                {
                    sr.flipX = true;
                    sr.flipY = true;
                }
                else
                {
                    sr.flipX = false;
                    sr.flipY = false;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (rb.linearVelocityX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // facing right
        }
        else if (rb.linearVelocityX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // facing left
        }

        anim.SetBool("isGrounded", IsGrounded());
        anim.SetBool("isDashing", rb.gravityScale == 0);

        anim.SetFloat("xVel", Mathf.Abs(rb.linearVelocityX));
        anim.SetFloat("yVel", rb.linearVelocityY);
    }

    private bool IsGrounded()
    {
        if (rb.linearVelocityY > 1f) // 1f instead of 0f for better jump responsiveness
        {
            print("meow");
            return false; // if moving upwards, not grounded
        }
         
        // Implement ground check logic here
        RaycastHit2D[] bottomCollisions = Physics2D.BoxCastAll(transform.position
                                                             + 1.5f * Vector3.down, new Vector2(1f, 0.2f), 0f, Vector2.zero);

        Debug.DrawLine(transform.position, transform.position + 1.5f * Vector3.down, Color.red);


        foreach (var collision in bottomCollisions)
        {
            if (collision.collider != coll)
            {
                return true;
            }
        }

        return false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (context.started && IsGrounded())
        {
            particleManager.OnMoveStart();
        }
        else if (context.canceled)
        {
            particleManager.OnMoveEnd();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && doubleJumpAvailable)
        {
            if (!IsGrounded())
            {
                doubleJumpAvailable = false; // Consume double jump
            }

            rb.linearVelocityY = jumpForce;
            rb.linearVelocityX = moveInput.x * moveSpeed; // instant horizontal control

            // trigger jump animation
            anim.SetTrigger("Jump");

            // trigger jump particles
            particleManager.OnJump();

            // stop movement particles during jump
            particleManager.OnMoveEnd();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed && dashCooldown.IsReady())
        {
            StartCoroutine("DashCoroutine");
            dashCooldown.Trigger();

            // trigger dash animation
            anim.SetTrigger("Dash");
        }
    }

    IEnumerator DashCoroutine()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // disable gravity during dash

        // trigger dash particles
        particleManager.OnMoveStart();

        // determine dash direction (if not pressing anything, base it off previously pressed horizontal direction)
        float dir = moveInput.x != 0 ? moveInput.x : facingDirection;

        Vector2 dashDirection = new Vector2(dir, 0).normalized;
        rb.linearVelocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashDuration); // pause for dash duration
        rb.gravityScale = originalGravity; // restore original gravity

        // stop dash particles
        particleManager.OnMoveEnd();
    }
}

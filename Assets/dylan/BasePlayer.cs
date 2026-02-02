using System;
using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
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
    private Rigidbody2D rb;
    private Collider2D coll;

    private Vector2 moveInput;
    private bool doubleJumpAvailable = true;
    private bool isGrounded;

    private float moveSpeed = 5f;
    private float jumpForce = 10f;
    private float dashForce = 15f;
    private float dashDuration = 0.2f; // in seconds
    private Cooldown dashCooldown = new Cooldown(5f); // 2 seconds cooldown
    private float airControl = 3f;

    // method to assign values to the player attributes
    public void AssignValues(float moveSpeed, float jumpForce, float dashForce, float dashDuration, Cooldown dashCooldown, float airControl)
    {
        this.moveSpeed = moveSpeed;
        this.jumpForce = jumpForce;
        this.dashForce = dashForce;
        this.dashDuration = dashDuration;
        this.dashCooldown = dashCooldown;
        this.airControl = airControl;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (IsGrounded() && rb.gravityScale != 0)
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
        if (context.performed && dashCooldown.IsReady())
        {
            StartCoroutine("DashCoroutine");
            dashCooldown.Trigger();
        }
    }

    IEnumerator DashCoroutine()
    {
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // disable gravity during dash

        // determine dash direction (if not pressing anything, base it off previously pressed horizontal direction)
        Vector2 dashDirection = new Vector2(Mathf.Sign(moveInput.x) != 0 ? Mathf.Sign(moveInput.x) : transform.localScale.x, 0).normalized;
        rb.linearVelocity = dashDirection * dashForce;

        yield return new WaitForSeconds(dashDuration); // pause for dash duration
        rb.gravityScale = originalGravity; // restore original gravity
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 15f;
    public PlayerHandler pH;
    public GameManager GM;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        rb2d.linearVelocity = ctx.ReadValue<Vector2>() * new Vector2(speed, speed);
    }
}
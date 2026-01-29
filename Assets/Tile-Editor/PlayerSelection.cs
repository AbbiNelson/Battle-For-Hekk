using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelection : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 15f;
    public PlayerHandler pH;
    void Start()
    {
        pH = GameObject.Find("PlayerHandler").GetComponent<PlayerHandler>();
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        pH.SelectSprite();
        pH.playerCount++;
        spriteRenderer.sprite = pH.selectedSprite;
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        rb2d.linearVelocity = ctx.ReadValue<Vector2>() * new Vector2(speed, speed);
    }
    public void Interact() { 
    
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSelectionMainMenu : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 15f;
    public PlayerPreloader pH;
    public bool selected = false;
    public GameObject charObj;
    public int playerNum;
    void Start()
    {
        pH = FindFirstObjectByType<PlayerPreloader>();
        rb2d = GetComponent<Rigidbody2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        pH.SelectSprite();
        pH.playerCount++;
        spriteRenderer.sprite = pH.selectedSprite;
        playerNum = pH.playerCount;

    }
    public void Move(InputAction.CallbackContext ctx)
    {
        rb2d.linearVelocity = ctx.ReadValue<Vector2>() * new Vector2(speed, speed);
    }
    public void Interact() {
        Debug.Log("Player " + playerNum + " pressed Interact");
        if (charObj == null)
        {
            Debug.Log("Player " + playerNum + " tried to select a character but is not in range of any character");
            return;
        }
        if (charObj.tag == "Jp") {
            PlayerSelData.CharOptions[playerNum - 1] = 1;
            Debug.Log("Player " + playerNum + " selected Jp");
        }
        if (charObj.tag == "Tp") {
            PlayerSelData.CharOptions[playerNum - 1] = 3;
            Debug.Log("Player " + playerNum + " selected Tp");
        }
        if (charObj.tag == "Wp") {
            PlayerSelData.CharOptions[playerNum - 1] = 0;
            Debug.Log("Player " + playerNum + " selected Wp");
        }
        if (charObj.tag == "Dp") {
            PlayerSelData.CharOptions[playerNum - 1] = 2;
            Debug.Log("Player " + playerNum + " selected Dp");
        }
        selected = true;
    }
    public void OnDestroy()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!selected)
            charObj = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!selected)
            charObj = null;
    }
}
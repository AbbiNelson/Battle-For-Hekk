using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private Cooldown dashCooldown = new(5f);
    [SerializeField] private float airControl = 3f;

    public void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log("New player joined: " + player.playerIndex);

        // Additional setup for the new player can be done here
        player.gameObject.GetComponent<BasePlayer>().AssignValues(
            moveSpeed: this.moveSpeed,
            jumpForce: this.jumpForce,
            dashForce: this.dashForce,
            dashDuration: this.dashDuration,
            dashCooldown: this.dashCooldown,
            airControl: this.airControl
        );
    }
}

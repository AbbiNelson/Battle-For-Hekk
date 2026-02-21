
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private Cooldown dashCooldown = new(2f);
    [SerializeField] private float airControl = 3f;

    [SerializeField] private RuntimeAnimatorController[] playerAnimatorController;
    [SerializeField] private Material[] playerMaterials;

    public void OnPlayerJoined(PlayerInput player)
    {
        Debug.Log("New player joined: " + player.playerIndex);

        // Additional setup for the new player can be done here
        BasePlayer playerScript = player.gameObject.GetComponent<BasePlayer>();

        playerScript.AssignValues(
            moveSpeed: this.moveSpeed,
            jumpForce: this.jumpForce,
            dashForce: this.dashForce,
            dashDuration: this.dashDuration,
            dashCooldown: this.dashCooldown,
            airControl: this.airControl
        );

        playerScript.AssignAnimation(this.playerAnimatorController[player.playerIndex % playerAnimatorController.Length]);
        playerScript.AssignColor(playerMaterials[player.playerIndex % playerMaterials.Length]);
    }
}

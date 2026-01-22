using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimGernade : MonoBehaviour
{
    [SerializeField] private GameObject grenade;

    private Vector2 worldPosition;
    private Vector2 direction;
    private void Update()
    {
        HandleGunRotation();
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)grenade.transform.position).normalized;
        grenade.transform.right = direction;
    }
}

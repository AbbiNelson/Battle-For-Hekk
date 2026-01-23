using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShotgun : MonoBehaviour
{
    [SerializeField] private GameObject gun;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private void Update()
    {
        HandleGunRotation();
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        Vector3 localScale = Vector3.one;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    
}

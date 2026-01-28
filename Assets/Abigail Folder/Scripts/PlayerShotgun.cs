using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerShotgun : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] bulletSpawnPoint;

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private void Update()
    {
        HandleGunRotation();
        HandleGunShooting();
    }

    private void HandleGunShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            for (int i = 0; i < bulletSpawnPoint.Length; i++)
            {
                bulletInst = Instantiate(bullet, bulletSpawnPoint[i].position, gun.transform.rotation);
            }
        }
    }

    private void HandleGunRotation()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        Vector3 localScale = Vector3.one;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;
    }    
}

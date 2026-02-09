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
    public float recoilForce = 5f;
    private float timeLeft;
    public float resetTime;
    public AudioSource Shoot;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private void Update()
    {
       
        timeLeft -= Time.deltaTime;
        
    }

    public void Recoil()
    {
        GetComponent<Rigidbody2D>().AddForce(-direction * recoilForce);
    }

    public void HandleGunShooting(InputAction.CallbackContext ctx)
    {
        if (ctx.started && timeLeft <= 0f)
        {
            for (int i = 0; i < bulletSpawnPoint.Length; i++)
            {
                bulletInst = Instantiate(bullet, bulletSpawnPoint[i].position, gun.transform.rotation);
                Recoil();
                
            }
            Shoot.Play();
            timeLeft = resetTime;
        }
    }

    public void HandleGunRotationMouse(InputAction.CallbackContext ctx)
    {
        worldPosition = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

    }    

    public void HandleGunRotationGamepad(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            gun.transform.right = ctx.ReadValue<Vector2>().normalized;
        }
    }
}

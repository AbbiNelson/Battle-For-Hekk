using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MolotovThrow : MonoBehaviour
{
    public AudioSource Fireball;
    public Transform firePosition;
    public GameObject Molotov;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;
    public GameObject cooldown;


    public void Shoot(InputAction.CallbackContext ctx)
    {
        
        if (!ctx.performed || Time.time < nextFireTime)
        {
            return;
        }
        
        Fireball.Play();
        var basePlayer = GetComponentInChildren<PlayerRotation>();

        Instantiate(Molotov, firePosition.position, basePlayer.facingDirection == 1 ? firePosition.rotation : firePosition.rotation * Quaternion.Euler(0f, 180f, 0f));
        nextFireTime = Time.time + cooldownTime;
    }
    private void Update()
    {
        if (((nextFireTime - Time.time) / cooldownTime) >= 0)
        {
            cooldown.transform.localScale = new Vector3(((nextFireTime - Time.time) / cooldownTime) * 1.5f, 0.07f, 1);

        }
        else
        {
            cooldown.transform.localScale = new Vector3(0, 0.07f, 1);
        }
    }
}


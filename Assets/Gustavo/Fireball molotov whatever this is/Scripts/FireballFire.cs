using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class MolotovThrow : MonoBehaviour
{
    public AudioSource Fireball;
    public Transform firePosition;
    public GameObject Molotov;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;


    public void Shoot(InputAction.CallbackContext ctx)
    {
        Fireball.Play();
        if (!ctx.performed || Time.time < nextFireTime)
            return;

        BasePlayer basePlayer = GetComponent<BasePlayer>();

        Instantiate(Molotov, firePosition.position, firePosition.rotation);
        nextFireTime = Time.time + cooldownTime;
    }
}


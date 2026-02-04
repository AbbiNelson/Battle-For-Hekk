using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class DotThrow : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Dot;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed || Time.time < nextFireTime)
            return;

        BasePlayer basePlayer = GetComponent<BasePlayer>();

        Instantiate(Dot, firePosition.position, basePlayer.facingDirection == 1 ? firePosition.rotation : firePosition.rotation * Quaternion.Euler(0f, 180f, 0f));
        nextFireTime = Time.time + cooldownTime;
    }
}

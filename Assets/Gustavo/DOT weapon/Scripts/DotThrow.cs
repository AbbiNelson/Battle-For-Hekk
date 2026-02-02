using Unity.Cinemachine;
using UnityEngine;

public class DotThrow : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Dot;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;


    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();

            Instantiate(Dot, firePosition.position, playerMovement.facingDirection == 1 ? firePosition.rotation : firePosition.rotation * Quaternion.Euler(0f, 180f, 0f));
            nextFireTime = Time.time + cooldownTime;
        }


    }
}

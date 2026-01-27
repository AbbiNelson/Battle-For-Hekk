using Unity.Cinemachine;
using UnityEngine;

public class MolotovThrow : MonoBehaviour
{
    public Transform firePosition;
    public GameObject Molotov;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;
    public float rotationSpeed = 100f;

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
            Instantiate(Molotov, firePosition.position, firePosition.rotation);
            nextFireTime = Time.time + cooldownTime;
        }
        
       
    }
}

using Unity.Cinemachine;
using UnityEngine;

public class MolotovThrow : MonoBehaviour
{
    public AudioSource Fireball;
    public Transform firePosition;
    public GameObject Molotov;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;
   

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Instantiate(Molotov, firePosition.position, firePosition.rotation);
            Fireball.Play();
            nextFireTime = Time.time + cooldownTime;
        }
        
       
    }
}

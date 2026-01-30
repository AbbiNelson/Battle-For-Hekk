using Unity.Cinemachine;
using UnityEngine;

public class DotThrow : MonoBehaviour
{
    public AudioSource ZAPP;
    public Transform firePosition;
    public GameObject Dot;
    public float cooldownTime = 5f;
    public float nextFireTime = 0f;


    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        { 
            ZAPP.Play();
            Instantiate(Dot, firePosition.position, firePosition.rotation);
            nextFireTime = Time.time + cooldownTime;
        }


    }
}

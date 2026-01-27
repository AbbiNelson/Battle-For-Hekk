using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float nomralBulletSpeed = 15f;
    [SerializeField] private float destoryTime = 3f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDestroyTime();
        SetStraightVelocity();
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destoryTime);
    }

    private void SetStraightVelocity()
    {
        rb.linearVelocity = transform.right * nomralBulletSpeed;
    }
}

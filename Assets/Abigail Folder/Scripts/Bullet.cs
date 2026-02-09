using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float nomralBulletSpeed = 15f;
    [SerializeField] private float destoryTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;

    private Rigidbody2D rb;
    public float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetDestroyTime();
        SetStraightVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((whatDestroysBullet.value & (1 << collision.gameObject.layer)) > 0)
        {
            if (collision.TryGetComponent(out Health health))
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
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

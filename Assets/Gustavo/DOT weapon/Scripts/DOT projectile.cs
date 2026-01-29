using UnityEngine;
using System.Collections;

public class DOTprojectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public float projectileSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * projectileSpeed;

        Destroy(gameObject, 5f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<StatusEffectManager>() != null)
        {
            other.GetComponent<StatusEffectManager>().ApplyPoison(6);
        }
        Destroy(gameObject);
    }





}

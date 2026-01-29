using UnityEngine;

public class fireball : MonoBehaviour
{
    public float projectileSpeed;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public float lingerTime = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * projectileSpeed;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (impactEffect != null)
        {
            if(collision.tag == "Player")
            {
                var healthComponent = collision.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(35);
                }
            }
            
            GameObject impact = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(impact, lingerTime);
        }

        Destroy(gameObject);
    }

   
}

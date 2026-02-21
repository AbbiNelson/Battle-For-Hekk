using UnityEngine;

public class ObjectHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    private GameObject activeOuchieBurnInstance;
    private GameObject activeOuchiePoisonInstance;
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

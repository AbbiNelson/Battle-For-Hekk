using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
   
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

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
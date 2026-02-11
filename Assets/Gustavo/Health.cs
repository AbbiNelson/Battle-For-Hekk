using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
   
    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {

        if (health <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }


    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
}
using UnityEngine;

public class Health : MonoBehaviour
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

        if (health <= 0 && gameObject.tag == "PlaceAble")
        {
            transform.parent.gameObject.SetActive(false);
            health = maxHealth;
        }


    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            transform.parent.gameObject.SetActive(false);
            health = maxHealth;
        
            Destroy(activeOuchieBurnInstance);
            Destroy(activeOuchiePoisonInstance);
        }
    }
}
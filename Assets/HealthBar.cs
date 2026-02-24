using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = GetComponentInParent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((hp.health / hp.maxHealth) * 1.5f, 0.15f, 1);
    }
}

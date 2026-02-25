using UnityEngine;

public class cooldownBar : MonoBehaviour
{
    public float maxcooldownTime; // Total cooldown time in seconds
    public float cooldownTime; // Current cooldown time remaining
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((cooldownTime / maxcooldownTime) * 1.5f, 0.07f, 1);
    }
}

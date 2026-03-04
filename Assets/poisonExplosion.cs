using UnityEngine;

public class poisonExplosion : MonoBehaviour
{
    public GameObject Dot;
    public GameManager GM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GM = GameObject.Find("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        if (GM.Arena.activeInHierarchy == true)
        {
            Instantiate(Dot, gameObject.transform.position + new Vector3(0, -1, 0), Quaternion.Euler(0f, 180f, 0f));
            Instantiate(Dot, gameObject.transform.position + new Vector3(1, 0, 0), Quaternion.Euler(0f, 90f, 0f));
            Instantiate(Dot, gameObject.transform.position + new Vector3(0, 1, 0), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(Dot, gameObject.transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0f, 270f, 0f));
        }
    }
}

using UnityEngine;

public class RandomTile : MonoBehaviour
{
    public GameObject[] tileOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Randomize();
    }

    // Update is called once per frame
    void Update()
    {
     
    
    }
    public void Randomize(){ 
        Debug.Log("Randomizing Tile");
        Instantiate(tileOptions[Random.Range(0,tileOptions.Length)]);
    }
}

using System;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int playerCount =  -1;
    public Sprite selectedSprite;
    public Sprite[] spriteOptions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectSprite() {
        Debug.Log("Selecting Sprite for Player " + playerCount);
        selectedSprite = spriteOptions[playerCount];

    }
}

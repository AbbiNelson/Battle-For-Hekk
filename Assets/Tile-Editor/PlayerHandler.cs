using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    public int playerCount =  0;
    public Sprite selectedSprite;
    public Sprite[] spriteOptions;
    public PlayerInputManager managerinput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];

            if (device.displayName == "Keyboard" || device.displayName == "Xbox Controller")
            {
                var input = managerinput.JoinPlayer(pairWithDevice: device);
            }
        }

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

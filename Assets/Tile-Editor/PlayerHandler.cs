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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnTokens() {
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];

            if (device is Gamepad)
            {
                var input = managerinput.JoinPlayer(pairWithDevice: device);
            }
        }
        playerCount = 0;
    }
    public void SelectSprite() {
        Debug.Log("Selecting Sprite for Player " + playerCount);
        selectedSprite = spriteOptions[playerCount];

    }
}

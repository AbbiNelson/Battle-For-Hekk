using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPreloader : MonoBehaviour
{
    public int playerCount = 0;
    public Sprite selectedSprite;
    public Sprite[] spriteOptions;
    public PlayerInputManager managerinput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayers();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnPlayers()
    {
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];

            if (device is Gamepad)
            {
                Debug.Log("Joining Player " + playerCount + " with device: " + device.displayName);

                var input = managerinput.JoinPlayer(pairWithDevice: device);
            }
        }
    }
    public void SelectSprite()
    {
        Debug.Log("Selecting Sprite for Player " + playerCount);
        selectedSprite = spriteOptions[playerCount];

    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPreloader : MonoBehaviour
{
    public PlayerInputManager managerinput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SpawnPlayers()
    {
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];

            if (device is Gamepad)
            {
                var input = managerinput.JoinPlayer(pairWithDevice: device);
            }
        }
    }
}

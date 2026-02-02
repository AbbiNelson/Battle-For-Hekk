using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject Arena;
    public GameObject TileSelection;
    public float PlayerSelection;
    public float DCount;
    public float PlayerCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arena.SetActive(true);
        TileSelection.SetActive(false);
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];

            if (device.displayName == "Keyboard" || device.displayName == "Xbox Controller")
            {
                DCount++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update works.");
        if (PlayerCount <= 1) {
            Arena.SetActive(false);
            TileSelection.SetActive(true);
        }
        if (PlayerSelection == DCount) {
            Arena.SetActive(true);
            TileSelection.SetActive(false);
        }
    }
}

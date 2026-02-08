using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject Arena;
    public GameObject TileSelection;
    public float PlayerSelection;
    public float DCount;
    public float PlayerCount;
    public bool inTileSelection;
    public TileNum TN;
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
        if (PlayerCount <= 1) {
            Arena.SetActive(false);
            TileSelection.SetActive(true);
            inTileSelection = true;
            TN.ClearGeneratedTiles();
            TN.TileGen();

        }
        if (PlayerSelection == DCount) {
            Arena.SetActive(true);
            Arena.GetComponent<TilemapCollider2D>().enabled = false;
            TileSelection.SetActive(false);
            inTileSelection = false;
        }
    }
}

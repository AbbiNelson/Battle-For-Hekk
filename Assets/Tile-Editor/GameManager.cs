using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject Arena;
    public GameObject TileSelection;
    public float PlayerSelection;
    public float DCount;
    public int PlayerCount; // changed from float to int to represent a count
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
    void Update(){
        // refresh the player list each frame and update PlayerCount
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        PlayerCount = players.Length;
        GameObject[] playertokens = GameObject.FindGameObjectsWithTag("PlayerToken");

        if (PlayerCount <= 1 && Arena.activeInHierarchy) {
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

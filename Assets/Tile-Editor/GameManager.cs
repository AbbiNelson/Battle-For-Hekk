using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject Arena;
    public GameObject TileSelection;
    public float PlayerSelection;
    public int PlayerTokenCount;
    public int PlayerCount;
    public bool inTileSelection;
    public TileNum TN;
    public bool combat;
    public PlayerHandler PH;
    public GameObject[] disabledtiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Arena.SetActive(true);
        TileSelection.SetActive(false);
        PH.SpawnPlayers();
    }

    // Update is called once per frame
    void Update(){
        // refresh the player list each frame and update PlayerTokenCount
        var activeplayers = GameObject.FindObjectsByType<GeneralSwitch>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        PlayerTokenCount = activeplayers.Length;

        var placedtiles = FindObjectsByType<TileDisable>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        
        var player = FindObjectsByType<GeneralSwitch>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        PlayerCount = player.Length;
        
        var playertokens = FindObjectsByType<NewTile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (PlayerTokenCount == 1)
        {
            activeplayers[0].GetComponent<pointSys>().AddPoints(1);
            Arena.SetActive(false);
            TileSelection.SetActive(true);
            inTileSelection = true;
            TN.ClearGeneratedTiles();
            TN.TileGen();
            for (int i = 0; i < placedtiles.Length; i++)
            {
                placedtiles[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < playertokens.Length; i++)
            {
                playertokens[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < player.Length; i++)
            {
                player[i].gameObject.SetActive(false);
            }
        }
        playertokens = FindObjectsByType<NewTile>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        if (Arena.activeInHierarchy && PlayerSelection == 0 && PlayerTokenCount == 0)
        {
            Arena.GetComponent<TilemapCollider2D>().enabled = true;
            for (int i = 0; i < player.Length; i++)
            {
                player[i].gameObject.SetActive(true);

            }
            for (int i = 0; i < playertokens.Length; i++)
            {
                playertokens[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < placedtiles.Length; i++)
            {
                placedtiles[i].gameObject.SetActive(true);
            }

        }
        
        if (PlayerSelection == playertokens.Length && inTileSelection) {
            Arena.SetActive(true);
            Arena.GetComponent<TilemapCollider2D>().enabled = false;
            TileSelection.SetActive(false);
            inTileSelection = false;
        }
    }
}

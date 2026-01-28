using UnityEngine;

public class TileNum : MonoBehaviour
{
    public int tileNum;
    public GameObject RGT; // RandomGenTile (prefab)
    public GameObject[] RGTL; // RandomGenTileList

    // Bounds: between (X = -25, Y = 13) and (X = 25, Y = -13)
    public const float MinX = -25f;
    public const float MaxX = 25f;
    public const float MinY = -13f;
    public const float MaxY = 13f;
    private const float FixedZ = 0f;

    private void Awake()
    {
        TileGen();
    }

    public void TileGen()
    {
        if (RGT == null || tileNum <= 0)
        {
            RGTL = new GameObject[0];
            return;
        }

        // Allocate an array sized to the requested numbe   r of tiles
        RGTL = new GameObject[tileNum];

        for (int i = 0; i < tileNum; i++)
        {
            // Randomize X between -25 and 25, Y between -13 and 13
            float randomX = Random.Range(MinX, MaxX);
            float randomY = Random.Range(MinY, MaxY);
            Vector3 pos = new Vector3(randomX, randomY, FixedZ);

            // Instantiate at randomized position and parent to this transform
            RGTL[i] = Instantiate(RGT, pos, Quaternion.identity, transform);
        }
    }

    // Call this to destroy all generated tiles and clear the array
    public void ClearGeneratedTiles()
    {
        if (RGTL == null)
            return;

        for (int i = 0; i < RGTL.Length; i++)
        {
            if (RGTL[i] != null)
                Destroy(RGTL[i]);

            RGTL[i] = null;
        }

        RGTL = new GameObject[0];
    }
}

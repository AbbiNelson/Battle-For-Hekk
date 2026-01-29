using UnityEngine;
using UnityEngine.InputSystem;

public class TileNum : MonoBehaviour
{
    public int tileNum;
    public GameObject[] tileList; // stores generated instances
    public GameObject[] tileOptions; // prefabs to pick from

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
        // Allocate an array sized to the requested number of tiles
        tileList = new GameObject[Random.Range(InputSystem.devices.Count, tileNum)];

        for (int i = 0; i < tileNum; i++)
        {
            // Randomize X between -25 and 25, Y between -13 and 13
            float randomX = Random.Range(MinX, MaxX);
            float randomY = Random.Range(MinY, MaxY);
            Vector3 pos = new Vector3(randomX, randomY, FixedZ);

            // Pick a random prefab from tileOptions
            int optionIndex = Random.Range(0, tileOptions.Length);
            GameObject chosenPrefab = tileOptions[optionIndex];

            // Instantiate at randomized position and parent to this transform
            tileList[i] = Instantiate(chosenPrefab, pos, Quaternion.identity, transform);

            Debug.Log($"Generated tile [{i}] using option {optionIndex} at position: {pos}");
        }
    }

    // Call this to destroy all generated tiles and clear the array
    public void ClearGeneratedTiles()
    {
        for (int i = 0; i < tileList.Length; i++)
        {
            if (tileList[i] != null)
                Destroy(tileList[i]);

            tileList[i] = null;
        }

        tileList = new GameObject[0];
    }
}

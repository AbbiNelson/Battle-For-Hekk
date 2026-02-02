using UnityEngine;

public class GridSnap : MonoBehaviour
{
    // Assign in Inspector or let Start find the Grid named "LevelGrid".
    public Grid grid;

    // If true the object will be snapped every frame. If false you can call ForceSnap() manually.
    public bool snapEveryFrame = false;
    // Snap once on Start if true.
    public bool snapOnStart = true;

    void Start()
    {
        var go = GameObject.FindWithTag("Grid");
        // returns the first active Grid found in the scene (or null)
        grid = go.GetComponent<Grid>();

        if (snapOnStart)
        {
            ForceSnap();
        }
    }

    void Update()
    {
        if (snapEveryFrame)
        {
            ForceSnap();
        }
    }

    // Forces the object's center to the center of the nearest grid cell (world-space).
    public void ForceSnap()
    {
        Vector3Int cell = grid.WorldToCell(transform.position);
        transform.position = grid.GetCellCenterWorld(cell);
    }
}
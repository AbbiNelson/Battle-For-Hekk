using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewTile : MonoBehaviour
{
    public GameObject tile;
    public GameManager GM;
    public bool selected = false;
    public GameObject go;

    void Start()
    {
        GameObject GMO = GameObject.FindWithTag("Master");
        GM = GMO.GetComponent<GameManager>();
        go = GameObject.FindWithTag("Grid");
    }

    // Called by the Input System action; wire this in your InputAction (performed)
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (GM.inTileSelection)
            {
                tile.transform.SetParent(transform, false);
                tile.transform.localPosition = Vector3.zero;
                tile.transform.localRotation = Quaternion.identity;

                if (tile == null)
                    return;
                Debug.Log($"NewTile: Parented '{tile.name}' to '{name}'.");
                GM.PlayerSelection += 1;
                selected = true;
            }
            else
            {
                go = GameObject.FindWithTag("Grid");
                tile.transform.SetParent(go.transform, true);
                GM.PlayerSelection -= 1;
                tile = null;
                selected = false;

            }
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!selected)
            tile = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(!selected)    
            tile = null;
    }
}

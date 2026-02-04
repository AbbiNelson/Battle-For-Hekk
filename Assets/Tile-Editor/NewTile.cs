using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewTile : MonoBehaviour
{
    public GameObject tile;
    public GameManager GM;
    public bool selected = false;

    void Start()
    {
        GameObject GMO = GameObject.FindWithTag("Master");
        GM = GMO.GetComponent<GameManager>();
    }

    // Called by the Input System action; wire this in your InputAction (performed)
    public void Interact(InputAction.CallbackContext ctx)
    {

        if (GM.inTileSelection)
        {
            tile.transform.SetParent(transform, false);
            tile.transform.localPosition = Vector3.zero;
            tile.transform.localRotation = Quaternion.identity;
            selected = true;
            if (tile == null)
                return;
            Debug.Log($"NewTile: Parented '{tile.name}' to '{name}'.");
            GM.PlayerSelection += 1;
        }
        else { 

            tile.transform.SetParent(null);
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

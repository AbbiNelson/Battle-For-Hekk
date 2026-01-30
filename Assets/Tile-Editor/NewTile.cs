using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NewTile : MonoBehaviour
{
    public GameObject tile;


    void Update()
    {
    }

    // Called by the Input System action; wire this in your InputAction (performed)
    public void Interact(InputAction.CallbackContext ctx)
    {
        if (tile == null)
            return;

        tile.transform.SetParent(transform, false);
        tile.transform.localPosition = Vector3.zero;
        tile.transform.localRotation = Quaternion.identity;


        Debug.Log($"NewTile: Parented '{tile.name}' to '{name}'.");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        tile = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            tile = null;
    }
}

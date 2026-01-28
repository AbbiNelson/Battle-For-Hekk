using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewTile : MonoBehaviour
{
    public GameObject blankTilePrefab;
    public bool createTileAtMouse = false;
    public RandomTile rTS;


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && createTileAtMouse)
        {
            CreateTileAtMouse();
        }
    }
    public void OnCreateTileButton()
    {
        createTileAtMouse = !createTileAtMouse;
    }

    private void CreateTileAtMouse()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = transform.position.z;
        GameObject inst = Instantiate(blankTilePrefab, mouseWorld, Quaternion.identity);

     }
}

using UnityEngine;
using UnityEngine.U2D;

public class GeneralSwitch : MonoBehaviour
{
    public PlayerHandler Ph;
    public pointSys PS;
    public GameObject[] objectsToToggle; // Array of objects to toggle
    public int indexToToggle;
    private void Start()
    {
        Ph = FindAnyObjectByType<PlayerHandler>().GetComponent<PlayerHandler>();
        Switch(PlayerSelData.CharOptions[indexToToggle]);
    }
    public void Switch(int index)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false); // Deactivate all objects
        }

        objectsToToggle[index].SetActive(true); // Toggle the active state of the specified object
        objectsToToggle[index].GetComponent<SpriteRenderer>().material = Ph.playerColors[indexToToggle];
        var Reallygay = objectsToToggle[index].GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sr in Reallygay)
        {
            sr.material = Ph.playerColors[indexToToggle];
        }
    }
}

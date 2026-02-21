using UnityEngine;

public class GeneralSwitch : MonoBehaviour
{
    public PlayerHandler Ph; // Reference to the PlayerInput component
    public GameObject[] objectsToToggle; // Array of objects to toggle
    public int indexToToggle;
    private void Start()
    {
        Ph = FindAnyObjectByType<PlayerHandler>().GetComponent<PlayerHandler>();
        indexToToggle = Ph.playerIndex;
        Ph.playerIndex++;
        Switch(PlayerSelData.CharOptions[indexToToggle]);
    }
    public void Switch(int index)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false); // Deactivate all objects
        }

        objectsToToggle[index].SetActive(true); // Toggle the active state of the specified object
    }
}

using System.Collections.Generic;
using UnityEngine;

public class GeneralSwitch : MonoBehaviour
{
    public GameObject[] objectsToToggle; // Array of objects to toggle

    public void Switch(int index)
    {
        foreach (GameObject obj in objectsToToggle)
        {
            obj.SetActive(false); // Deactivate all objects
        }

        objectsToToggle[index].SetActive(true); // Toggle the active state of the specified object
    }
}

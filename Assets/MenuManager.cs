using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var players = GameObject.FindObjectsByType<PlayerSelectionMainMenu>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        Debug.Log(players.Length);
        if (players.Length == 0)
        {
            SceneManager.LoadScene("Arena-One");
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].selected) {
                players[i].gameObject.SetActive(false);
                }
        }
    }
}

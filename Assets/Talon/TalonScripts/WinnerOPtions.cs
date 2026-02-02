using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerOPtions : MonoBehaviour
{
    public void LeaveGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

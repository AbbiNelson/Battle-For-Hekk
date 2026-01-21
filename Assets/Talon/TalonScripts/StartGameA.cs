using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameA : MonoBehaviour
{
    public GameObject text;
    bool isTextActive = true;
    public float delay = 1f;
    public void OnPressA(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Start Game A Pressed");
            // Add your logic to start Game A here
        }
    }
    public void OnPressB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Exit Game B Pressed");
            // Add your logic to start Game B here
            Application.Quit();
        }
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (isTextActive && delay == 0f)
        {
            text.SetActive(true);
            isTextActive = false;
            delay = 1f;
        }
        else if (isTextActive == false && delay == 0f)
        {
            text.SetActive(false);
            isTextActive = true;
            delay = 1f;
        }
    }
}

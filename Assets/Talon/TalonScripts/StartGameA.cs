using UnityEngine;
using UnityEngine.InputSystem;

public class StartGameA : MonoBehaviour
{
    public void OnPressA(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Start Game A Pressed");
            // Add your logic to start Game A here
        }
    }
}

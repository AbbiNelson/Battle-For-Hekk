using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        print(context.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        print("moly");
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        print("guacalmolle");
    }
}

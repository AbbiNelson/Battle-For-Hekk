using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.Controls;

public class GamepadCursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursorTransform;

    [SerializeField] PlayerInput playerInput;

    [SerializeField] float cursorSpeed = 1000f;

    private bool previousMouseState;

    private Mouse virtualMouse;
    private void OnEnable()
    {
        if (virtualMouse == null)
        {
            virtualMouse = (Mouse) InputSystem.AddDevice("VirtualMouse");
        }
        else if (!virtualMouse.added)
        {
            InputSystem.AddDevice(virtualMouse);
        }

        InputUser.PerformPairingWithDevice(virtualMouse, playerInput.user);

        if (cursorTransform != null)
        {
            Vector2 position = cursorTransform.anchoredPosition;
            InputState.Change(virtualMouse.position, position);
        }

        InputSystem.onAfterUpdate += UpdateMotion;
    }

    private void OnDisable()
    {
        InputSystem.onAfterUpdate -= UpdateMotion;
        if (virtualMouse != null && virtualMouse.added)
        {
            InputSystem.RemoveDevice(virtualMouse);
        }
    }
    private void UpdateMotion()
    {
        if (virtualMouse == null || Gamepad.current == null)
        {
            return;
        }
        Vector2 stickValue = Gamepad.current.leftStick.ReadValue();

        stickValue *= cursorSpeed * Time.deltaTime;

        Vector2 currentPosition = virtualMouse.position.ReadValue();

        Vector2 newPosition = currentPosition + stickValue;

        newPosition.x = Mathf.Clamp(newPosition.x, 0, Screen.width);
        newPosition.y = Mathf.Clamp(newPosition.y, 0, Screen.height);

        InputState.Change(virtualMouse.position, newPosition);

        InputState.Change(virtualMouse.delta, stickValue);

        bool aButtonIsPressed = Gamepad.current.aButton.IsPressed();
        if (previousMouseState != aButtonIsPressed)
        {
            virtualMouse.CopyState<MouseState>(out var mouseState);
            
            //mouseState.WithButton(MouseButton.Left, aButtonIsPressed);

            InputState.Change(virtualMouse, mouseState);

            previousMouseState = aButtonIsPressed;
        }
    }
}

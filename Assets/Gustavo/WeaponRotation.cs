using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   

   


    public void AimMouse(InputAction.CallbackContext ctx)
    {
        Vector3 mousePosition = ctx.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

    }

    public void AimController(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            transform.up = ctx.ReadValue<Vector2>();

        }

    }
}
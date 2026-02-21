using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerRotation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float facingDirection;
    public bool overrideDirection;






    public void AimController(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            overrideDirection = true;
        else if (ctx.canceled)
            overrideDirection = false;

        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            transform.up = ctx.ReadValue<Vector2>();
            
            facingDirection = ctx.ReadValue<Vector2>().x < 0 ? -1 : 1;
            GetComponentInParent<BasePlayer>().Flip(ctx.ReadValue<Vector2>().x > 0);
        }

    }
}
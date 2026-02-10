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




    public void AimMouse(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
            overrideDirection = true;
        else if (ctx.canceled)
            overrideDirection = false;


        // To do; Put this in update if needed
        Vector3 mousePosition = ctx.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Debug.Log(transform.parent.name + "; " + mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

        facingDirection = mousePosition.x < transform.parent.position.x ? -1 : 1;
        GetComponentInParent<BasePlayer>().Flip(mousePosition.x > transform.parent.position.x);
    }

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
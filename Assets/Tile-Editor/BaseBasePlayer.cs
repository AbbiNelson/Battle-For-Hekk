using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Unity.VisualScripting;

public class BaseBasePlayer : MonoBehaviour
{
    public void Move(InputAction.CallbackContext ctx)
    {

        Debug.Log("BaseBasePlayer: Move called");
        if(transform.GetChild(0).gameObject.activeSelf)
            GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnMove(ctx);
        if (transform.GetChild(1).gameObject.activeSelf)
            GetComponentsInChildren<PlayerSelection>().First(item => item.enabled).Move(ctx);

    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnJump(ctx);
        if (transform.GetChild(1).gameObject.activeSelf)
            GetComponentsInChildren<NewTile>().First(item => item.enabled).Interact(ctx);
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnDash(ctx);
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).GetChild(0).GetComponent<DotThrow>().Shoot(ctx);
            Debug.Log("BaseBasePlayer: Shoot called on DotThrow");
        }
        if (transform.GetChild(0).GetChild(1).gameObject.activeSelf)
        {
            transform.GetChild(0).GetChild(1).GetComponent<MolotovThrow>().Shoot(ctx);
            Debug.Log("BaseBasePlayer: Shoot called on MolotovThrow");
        }
        if (transform.GetChild(0).GetChild(2).gameObject.activeSelf)
        {
            transform.GetChild(0).GetChild(2).GetComponent<PlayerShotgun>().HandleGunShooting(ctx);
        }
        if (transform.GetChild(0).GetChild(3).gameObject.activeSelf)
        {
            transform.GetChild(0).GetChild(3).GetComponent<HitScan>().Shoot(ctx);
        }
    }

    public void AimMouse(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            GetComponentsInChildren<PlayerRotation>().First(item => item.enabled).AimMouse(ctx);
    }

    public void AimGamepad(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            GetComponentsInChildren<PlayerRotation>().First(item => item.enabled).AimController(ctx);
    }
}

using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using Unity.VisualScripting;

public class BaseBasePlayer : MonoBehaviour
{
    public void Move(InputAction.CallbackContext ctx)
    {
        GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnMove(ctx);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnJump(ctx);
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        GetComponentsInChildren<BasePlayer>().First(item => item.enabled).OnDash(ctx);
    }

    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (transform.GetChild(0).gameObject.activeSelf)
            transform.GetChild(0).GetComponent<DotThrow>().Shoot(ctx);
        if (transform.GetChild(1).gameObject.activeSelf)
            transform.GetChild(1).GetComponent<MolotovThrow>().Shoot(ctx);
        if (transform.GetChild(2).gameObject.activeSelf)
            transform.GetChild(2).GetComponent<PlayerShotgun>().HandleGunShooting(ctx);
        if (transform.GetChild(3).gameObject.activeSelf)
            transform.GetChild(3).GetComponent<HitScan>().Shoot(ctx);
    }

    public void AimMouse(InputAction.CallbackContext ctx)
    {
        GetComponentsInChildren<PlayerRotation>().First(item => item.enabled).AimMouse(ctx);
    }

    public void AimGamepad(InputAction.CallbackContext ctx)
    {
        GetComponentsInChildren<PlayerRotation>().First(item => item.enabled).AimController(ctx);
    }
}

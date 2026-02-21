using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitScan : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    public bool overrideDirection;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;


    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        //_muzzleFlashAnimator.SetTrigger(name: "Shoot");

        float dir = transform.GetChild(0).transform.up.x > 0 ? 1 : -1;
        Vector3 angle = dir == 1 ? rifle.transform.right : -rifle.transform.right;

        var hit = Physics2D.Raycast(
            origin: (Vector2)_gunPoint.position,
            direction: angle,
            _weaponRange
            );

        var trail = Instantiate(
            _bulletTrail,
            _gunPoint.position,
            transform.rotation
            );

        var trailScript = trail.GetComponent<Trail>();

        if (hit.collider != null)
        {
            trailScript.SetTargetPosition(hit.point);


        }
        else
        {
            var endPosition = _gunPoint.position + angle * _weaponRange;
            trailScript.SetTargetPosition(endPosition);
        }

        Debug.Log("Is Shooting");

    }

    //public void HandleGunRotationMouse(InputAction.CallbackContext ctx)
    //{
    //    if (ctx.started)
    //        overrideDirection = true;
    //    else if (ctx.canceled)
    //        overrideDirection = false;

    //    worldPosition = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    //    direction = (worldPosition - (Vector2)rifle.transform.position).normalized;
    //    rifle.transform.right = direction;
        
    //    //rifle.transform.localScale = localScale;
    //}

    //public void HandleGunRotationGamepad(InputAction.CallbackContext ctx)
    //{
    //    if (ctx.started)
    //        overrideDirection = true;
    //    else if (ctx.canceled)
    //        overrideDirection = false;

    //    if (ctx.ReadValue<Vector2>() != Vector2.zero)
    //    {
    //        rifle.transform.right = ctx.ReadValue<Vector2>().normalized;
    //    }
    //}
}

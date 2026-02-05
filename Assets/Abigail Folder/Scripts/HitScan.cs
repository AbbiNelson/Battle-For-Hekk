using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitScan : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject rifle;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    [SerializeField] private Animator _muzzleFlashAnimator;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;


    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (!ctx.started)
            return;

        //_muzzleFlashAnimator.SetTrigger(name: "Shoot");

        var hit = Physics2D.Raycast(
            origin: (Vector2)_gunPoint.position,
            direction: (Vector2)rifle.transform.right,
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
            var endPosition = _gunPoint.position + rifle.transform.right * _weaponRange;
            trailScript.SetTargetPosition(endPosition);
        }

        Debug.Log("Is Shooting");

    }

    public void HandleGunRotationMouse(InputAction.CallbackContext ctx)
    {
        worldPosition = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
        direction = (worldPosition - (Vector2)rifle.transform.position).normalized;
        rifle.transform.right = direction;
        
        //rifle.transform.localScale = localScale;
    }

    public void HandleGunRotationGamepad(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<Vector2>() != Vector2.zero)
        {
            rifle.transform.right = ctx.ReadValue<Vector2>().normalized;
        }
    }
}

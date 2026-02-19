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

}

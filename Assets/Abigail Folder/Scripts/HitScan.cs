using UnityEngine;

public class HitScan : MonoBehaviour
{
    [SerializeField] private Transform _gunPoint;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    [SerializeField] private Animator _muzzleFlashAnimator;


    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            _muzzleFlashAnimator.SetTrigger(name: "Shoot");

            var hit = Physics2D.Raycast(
                origin: (Vector2) _gunPoint.position,
                direction: (Vector2) transform.up,
                _weaponRange
                );

            var trail = Instantiate(
                _bulletTrail,
                _gunPoint.position,
                transform.rotation
                );
        }
    }
}

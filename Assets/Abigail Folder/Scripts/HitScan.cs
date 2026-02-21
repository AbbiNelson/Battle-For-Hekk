using UnityEngine;
using UnityEngine.InputSystem;

public class HitScan : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] bulletSpawnPoint;

    private GameObject bulletInst;
    public float recoilForce = 5f;
    private float timeLeft;
    public float resetTime;
    public AudioSource Shoot;


    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;
    private void Update()
    {

        timeLeft -= Time.deltaTime;

    }

    public void Recoil()
    {
        GetComponent<Rigidbody2D>().AddForce(-direction * recoilForce);
    }

    public void HandleGunShooting(InputAction.CallbackContext ctx)
    {
        float dir = transform.GetChild(0).transform.up.x > 0 ? 1 : -1;

        if (ctx.started && timeLeft <= 0f)
        {
            for (int i = 0; i < bulletSpawnPoint.Length; i++)
            {
                bulletInst = Instantiate(bullet, bulletSpawnPoint[i].position, gun.transform.rotation * Quaternion.Euler(0f, 0f, -90f));
                if (dir < 0)
                    bulletInst.transform.Rotate(0, 0, 180);

                Recoil();

            }
            Shoot.Play();
            timeLeft = resetTime;
        }
    }

    //public void HandleGunRotationMouse(InputAction.CallbackContext ctx)
    //{
    //    worldPosition = Camera.main.ScreenToWorldPoint(ctx.ReadValue<Vector2>());
    //    direction = (worldPosition - (Vector2)gun.transform.position).normalized;
    //    gun.transform.right = direction;

    //}

    //public void HandleGunRotationGamepad(InputAction.CallbackContext ctx)
    //{
    //    if (ctx.started)
    //        overrideDirection = true;
    //    else if (ctx.canceled)
    //        overrideDirection = false;

    //    if (ctx.ReadValue<Vector2>() != Vector2.zero)
    //    {
    //        transform.up = ctx.ReadValue<Vector2>();

    //        facingDirection = ctx.ReadValue<Vector2>().x < 0 ? -1 : 1;
    //        GetComponentInParent<BasePlayer>().Flip(ctx.ReadValue<Vector2>().x > 0);
    //    }
    //}
}
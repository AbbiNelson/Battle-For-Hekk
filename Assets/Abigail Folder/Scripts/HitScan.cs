using UnityEngine;

public class HitScan : MonoBehaviour
{
    public Collider2D myCollider;
    RaycastHit2D[] hits = new RaycastHit2D[5];
    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        int numHits = myCollider.Raycast(Vector2.right, hits);
    }
}

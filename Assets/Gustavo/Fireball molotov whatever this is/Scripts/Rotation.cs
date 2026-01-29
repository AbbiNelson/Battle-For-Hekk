using UnityEngine;

public class Rotation : MonoBehaviour
{
   public float rotationSpeed = 45f;
    void Update()
    {
        this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    
    
}

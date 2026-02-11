using Unity.Cinemachine;
using UnityEngine;

public class TargetGroup : MonoBehaviour
{
    private void Awake()
    {
        FindFirstObjectByType<CinemachineTargetGroup>().AddMember(transform, 1, 0);
    }
}

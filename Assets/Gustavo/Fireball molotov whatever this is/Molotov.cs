using Unity.VisualScripting;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    private static Molotov _instance;

    public static Molotov Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}

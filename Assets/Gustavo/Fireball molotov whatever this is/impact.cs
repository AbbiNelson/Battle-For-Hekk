using Unity.VisualScripting;
using UnityEngine;

public class impact : MonoBehaviour
{
    private static impact _instance;

    public static impact Instance
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

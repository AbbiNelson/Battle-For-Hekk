using Unity.VisualScripting;
using UnityEngine;

public class Molotov : MonoBehaviour
{
    public AudioSource Fireball;
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
            Fireball.Play();
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}

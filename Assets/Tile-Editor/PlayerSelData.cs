using UnityEngine;

public class PlayerSelData : MonoBehaviour
{
    public static PlayerSelData Instance { get; private set; }
    public static int[] CharOptions = new int[6];
    public int[] chars = CharOptions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

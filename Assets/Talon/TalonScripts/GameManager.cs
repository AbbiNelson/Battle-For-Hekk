using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public charselcter[] characters;

    public charselcter selectedCharacter;

    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if (characters.Length > 0 && selectedCharacter == null)
        {
            selectedCharacter = characters[0];
        }
    }

    public void SetCharacter(charselcter character)
    {
        selectedCharacter = character;
    }
}

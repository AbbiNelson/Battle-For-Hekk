using UnityEngine;
using UnityEngine.UI;

public class CharselUI : MonoBehaviour
{
    public GameObject optionPrefab;
    public Transform prevCharacter;
    public Transform selCharacter;

    private void Start()
    {
        foreach (charselcter c in GameManager.instance.characters)
        {
            GameObject option = Instantiate(optionPrefab, transform);
            Button button = option.GetComponent<Button>();

            button.onClick.AddListener(() =>
            {
                GameManager.instance.SetCharacter(c);
            if (selCharacter != null)
                {
                    prevCharacter = selCharacter;
                }
                selCharacter = option.transform;
            });
        }
    }
}

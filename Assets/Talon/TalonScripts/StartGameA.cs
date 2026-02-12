using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameA : MonoBehaviour
{
    private Animator transistionAnim;
    public GameObject text;
    bool isTextActive = true;
    private float delay = 0.5f;
    [HideInInspector] public bool canPress = true;

    private void Awake()
    {
        transistionAnim = GetComponent<Animator>();
    }

    public void OnPressA()
    {
        if (canPress)
        {
            Debug.Log("Start Game A Pressed");
            canPress = false;
            StartCoroutine(LoadLevel());
        }
    }
    public void OnPressB()
    {
            Debug.Log("Exit Game B Pressed");
            Application.Quit();
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {

            delay -= Time.deltaTime;
            if (isTextActive && delay <= 0f)
            {
                text.SetActive(true);
                isTextActive = false;
                delay = 0.5f;
            }
            else if (isTextActive == false && delay <= 0f)
            {
                text.SetActive(false);
                isTextActive = true;
                delay = 0.5f;
            }
        }
    }

    IEnumerator LoadLevel()
    {
        transistionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        transistionAnim.SetTrigger("Start");
    }
}

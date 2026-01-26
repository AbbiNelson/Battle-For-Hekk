using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class StartGameA : MonoBehaviour
{
    private Animator transistionAnim;
    public GameObject text;
    bool isTextActive = true;
    private float delay = 0.5f;
    bool canPress = true;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        transistionAnim = GetComponent<Animator>();
    }

    public void OnPressA(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canPress)
        {
            Debug.Log("Start Game A Pressed");
            canPress = false;
            StartCoroutine(LoadLevel());
            // Add your logic to start Game A here
        }
    }
    public void OnPressB(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Exit Game B Pressed");
            // Add your logic to start Game B here
            Application.Quit();
        }
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

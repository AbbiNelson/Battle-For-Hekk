using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinnerOPtions : MonoBehaviour
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

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 3)
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
        SceneManager.LoadSceneAsync("MainMenu");
        transistionAnim.SetTrigger("Start");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public StartGameA startGameA;
    public WinnerOPtions winnerOPtions;
    [Header("------ Audio Source ------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip aButton;

    private bool once = false;

    private void Awake()
    {
        musicSource.clip = background;
        sfxSource.clip = aButton;
        musicSource.Play();
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (winnerOPtions.canPress == false && sfxSource.isPlaying == false && once == false)
            {
                once = true;
                sfxSource.Play();
            }
        }

    }
}

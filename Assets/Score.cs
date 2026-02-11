using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreTextWim;
    public Text scoreTextDim;
    public Text scoreTextTim;
    public Text scoreTextJim;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreTextWim.text = " Wins:" + score.ToString();
        scoreTextDim.text = " Wins:" + score.ToString();
        scoreTextTim.text = " Wins:" + score.ToString();
        scoreTextJim.text = " Wins:" + score.ToString();
    }

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    public void AddPointW()
    {
        score += 1;
        scoreTextWim.text = " Wins:" + score.ToString();
    }
    public void AddPointD()
    {
        score += 1;
        scoreTextDim.text = " Wins:" + score.ToString();
    }
    public void AddPointT()
    {
        score += 1;
        scoreTextTim.text = " Wins:" + score.ToString();
    }
    public void AddPointJ()
    {
        score += 1;
        scoreTextJim.text = " Wins:" + score.ToString();
    }
}

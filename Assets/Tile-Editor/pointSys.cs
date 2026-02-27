using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class pointSys : MonoBehaviour
{
    public int playerIndex;
    public int points;
    public GameObject pointsBar;
    public GameObject pointsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetObjects(GameObject bar)
    {
        var BarOptions = FindObjectsByType<BarOption>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        bar.gameObject.SetActive(true);
        pointsBar = bar.GetComponentInChildren<Bar>().gameObject;
        pointsText = bar.GetComponentInChildren<text>().gameObject;

    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.GetComponent<TMP_Text>().text = points.ToString();
        pointsBar.GetComponent<Image>().fillAmount = (points / 10);
    }
}

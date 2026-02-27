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
    public void SetObjects(int index)
    {
        playerIndex = index;
        var BarOptions = FindObjectsByType<BarOption>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        BarOptions[index].gameObject.SetActive(true);
        pointsBar = BarOptions[index].GetComponentInChildren<Bar>().gameObject;
        pointsText = BarOptions[index].GetComponentInChildren<text>().gameObject;

    }
    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
        pointsText.GetComponent<TMP_Text>().text = points.ToString();
        pointsBar.GetComponent<Image>().fillAmount = (points / 10);
    }
}

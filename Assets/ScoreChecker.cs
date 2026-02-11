using UnityEngine;

public class ScoreChecker : MonoBehaviour
{
    public int PlayerTokenCount;
    public GameObject poisonCheck;
    public GameObject fireCheck;
    public GameObject shotgunCheck;
    public GameObject hitscanCheck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        GameObject[] activeplayers = GameObject.FindGameObjectsWithTag("Player");
        PlayerTokenCount = activeplayers.Length;

        if (activeplayers.Length == 1)
            {
            if (poisonCheck.activeSelf)
            {
                Score.instance.AddPointW();
            }
            if (fireCheck.activeSelf)
            {
                Score.instance.AddPointJ();
            }
            if (shotgunCheck.activeSelf)
            {
                Score.instance.AddPointD();
            }
            if (hitscanCheck.activeSelf)
            {
                Score.instance.AddPointT();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResTimeCalculate : MonoBehaviour
{
    public float goldSliverBound = 120;
    public float sliverBronzeBound = 240;
    public GameObject medalImage; 
    public Sprite[] images;

    // Start is called before the first frame update
    void Start()
    {
        Point[] pointsArray = RuleManager.ruleInstance.pointsArray;
        float[] timeArray = RuleManager.ruleInstance.timeArrayForPoints;
        string resText = "";
        for(int i = 0; i < timeArray.Length-1; i++)
        {
                resText += pointsArray[i].GetName() + " => " + pointsArray[i + 1].GetName() +
                    "  takes " + Timer.ToTimeFormat(timeArray[i + 1] - timeArray[i]) + "\n";
        }
        float levelTime = timeArray[timeArray.Length - 1];
        resText +=  "Total time is " +  Timer.ToTimeFormat(levelTime);
        this.GetComponent<Text>().text = resText;

        StartCoroutine(ShowMedal(levelTime));

        //Juage if the new time record is shorter than old one, and whether update
        float recordTime = LoadData.instance.GetLevelRecord()[SceneManager.GetActiveScene().buildIndex - 1];

        if (levelTime < recordTime || recordTime == 0)
        {
            LoadData.instance.ChangeLevelRecord(SceneManager.GetActiveScene().buildIndex, levelTime);
            LoadData.instance.LoadGame();
        }
    }

    private IEnumerator ShowMedal(float time)
    {
        yield return new WaitForSeconds(1.5f);

        if (time < goldSliverBound)
        {
            medalImage.GetComponent<Image>().sprite = images[0];
        }
        else if(time < sliverBronzeBound)
        {
            medalImage.GetComponent<Image>().sprite = images[1];
        }
        else
        {
            medalImage.GetComponent<Image>().sprite = images[2];
        }
        medalImage.SetActive(true);
        yield return null;
    }

}

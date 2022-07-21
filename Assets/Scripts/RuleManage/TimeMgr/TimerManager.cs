using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;
    Timer generalTimer;
    public GameObject totalTimeText;
    public GameObject partTimeText;
    public bool timerCanRun = true;
    
    private void Awake()
    {
        generalTimer = new Timer("GeneralTime");
        instance = this;
    }

    private void Start()
    {
        generalTimer.StartRecording();
    }

    private void Update()
    {
        if (timerCanRun)
        {
            totalTimeText.GetComponent<Text>().text = Timer.ToTimeFormat(generalTimer.GetCurrentRecord());
        }
    }

    public Timer GetTimer()
    {
        return generalTimer;
    }

    public void RecordTimePoint(int pointOrder)
    {
        var pointsArray = RuleManager.ruleInstance.pointsArray;
        var timeArrayForPoints = RuleManager.ruleInstance.timeArrayForPoints;
        pointsArray[pointOrder - 1].SetTime(generalTimer.GetCurrentRecord());
        timeArrayForPoints[pointOrder - 1] = generalTimer.GetCurrentRecord();
        partTimeText.GetComponent<Text>().text = "Last record: " + pointsArray[pointOrder - 1].GetName() + " " +
            Timer.ToTimeFormat(timeArrayForPoints[pointOrder - 1]) + "\nCurrent target: " + pointsArray[pointOrder].GetName();
    }

    public void EndPointProcessOnUIText()
    {
        partTimeText.GetComponent<Text>().text = "";
        timerCanRun = false;
    }
}
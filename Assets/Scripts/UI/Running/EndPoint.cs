using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    public GameObject LoadManager;
    private RuleManager CPArray; 

    private void Start()
    {
        CPArray = RuleManager.ruleInstance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CPArray.timeArrayForPoints[CPArray.timeArrayForPoints.Length - 2] != 0)
        {
            GameObject.Find("Player").GetComponent<PlayerControl>().canInput = false;
            LoadManager.GetComponent<LoadManager>().ResultBeforeLoadNextLevel();
            
            CPArray.pointsArray[CPArray.pointsArray.Length - 1].SetTime(TimerManager.instance.GetTimer().GetCurrentRecord());
            CPArray.timeArrayForPoints[CPArray.timeArrayForPoints.Length - 1] = TimerManager.instance.GetTimer().GetCurrentRecord();
            TimerManager.instance.EndPointProcessOnUIText();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndPoint : MonoBehaviour
{
    public GameObject LoadManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            GameObject.Find("Player").GetComponent<PlayerControl>().canInput = false;
            LoadManager.GetComponent<LoadManager>().LoadNextLevel();
            var CPArray = RuleManager.ruleInstance;
            CPArray.pointsArray[CPArray.pointsArray.Length - 1].SetTime(TimerManager.instance.GetTimer().GetCurrentRecord());
            CPArray.timeArrayForPoints[CPArray.timeArrayForPoints.Length - 1] = TimerManager.instance.GetTimer().GetCurrentRecord();
            TimerManager.instance.EndPointProcessOnUIText();
        }
    }

}

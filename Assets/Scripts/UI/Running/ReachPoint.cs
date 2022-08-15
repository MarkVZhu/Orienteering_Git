using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReachPoint : MonoBehaviour
{
    private bool canInteracte = false;
    private bool isReached = false;
    private bool OrderCorrect = false;
    public GameObject reachedEffect;
    public GameObject enterDialog;
    public GameObject reachedDialog;

    public float speed = 1.0f;
    public GameObject m_Image;
    public GameObject m_Text;

    public int targetProcess = 100;
    private float currentAmout = 0;

    // Update is called once per frame
    void Update()
    {
        if (canInteracte && !isReached)
        {
            LoadRingProcess();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isOrderCorrect();
        if (other.CompareTag("Player") && !isReached && OrderCorrect)
        { 
            canInteracte = true;
            enterDialog.SetActive(true);
        }
        else if(other.CompareTag("Player") && isReached)
        {
            reachedDialog.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteracte = false;
            m_Text.GetComponent<Text>().text = "Recording";
            enterDialog.SetActive(false);
            reachedDialog.SetActive(false);
        }

        if (!isReached)
        {
            currentAmout = 0;
        }
    }

    private void LoadRingProcess()
    {
        if (currentAmout < targetProcess)
        {
            currentAmout += speed;
            if (currentAmout > targetProcess)
            {
                currentAmout = targetProcess;
            }

            m_Image.GetComponent<Image>().fillAmount = currentAmout / 100.0f;
        }
        else
        {
            isReached = true;
            TimerManager.instance.RecordTimePoint(GetOrderThisPoint());
            m_Text.GetComponent<Text>().text = "Recorded";
            StartCoroutine(SetFireworkEffect());
        }
    }

    private IEnumerator SetFireworkEffect()
    {
        reachedEffect.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        reachedEffect.SetActive(false);
    }

    private int GetOrderThisPoint()
    {
        string pointName = this.transform.parent.name;
        int thisOrder = int.Parse(pointName.Substring(pointName.Length-1));
        return thisOrder;
    }

    private void isOrderCorrect()
    {
        if(GetOrderThisPoint() == 1)
        {
            OrderCorrect = true;
        }
        else if(RuleManager.ruleInstance.timeArrayForPoints[GetOrderThisPoint() - 2] != 0)
        {
            OrderCorrect = true;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLable;
    //public GameObject face01, face02;

    [Header("Player")]
    public PlayerControl PlayerControl; //When dialog is displaying, player cannot move

    bool lineFinished;

    List<string> textList = new List<string>();

    private void OnEnable()
    {
        //textLable.text = textList[index];
        //index++;
        PlayerControl.canInput = false;
        StartCoroutine(SetTextUI());
    }

    private void Start()
    {
        TimerManager.instance.GetTimer().PauseRecording();
    }

    IEnumerator SetTextUI()
    {
        textLable.text = "5";

        for (int i = 5; i >= 1; i--)
        {
            textLable.text = i + "";
            yield return new WaitForSeconds(1f);
        }
       
        gameObject.SetActive(false);
        PlayerControl.canInput = true;
        TimerManager.instance.GetTimer().RestartRecording();
        BGMManager.Instance.LevelMusicChange(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }
}

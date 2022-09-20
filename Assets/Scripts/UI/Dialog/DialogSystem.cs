using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLable;
    //public GameObject face01, face02;

    [Header("TXT File")]
    public TextAsset textFile; // Can be .txt, .html, .htm, .xml ...
    public int index; // The index of line in the .txt content
    public float textSpeed;
    public GameObject promptText;

    [Header("Player")]
    public PlayerControl PlayerControl; //When dialog is displaying, player cannot move

    bool lineFinished;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        //textLable.text = textList[index];
        //index++;
        PlayerControl.canInput = false;
        lineFinished = true;
        StartCoroutine(SetTextUI());
    }

    private void Start()
    {
        TimerManager.instance.GetTimer().PauseRecording();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            PlayerControl.canInput = true;
            TimerManager.instance.GetTimer().RestartRecording();
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) && lineFinished)
        {
            //textLable.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

       var lineDate =  file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        lineFinished = false;
        promptText.SetActive(false);
        textLable.text = "";

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLable.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        promptText.SetActive(true);
        lineFinished = true;
        index++; 
    }
}

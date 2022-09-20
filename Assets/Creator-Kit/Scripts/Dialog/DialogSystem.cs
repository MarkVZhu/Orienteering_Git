using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLable;
    public GameObject face01, face02;

    [Header("TXT File")]
    public TextAsset textFile; // Can be .txt, .html, .htm, .xml ...
    public int index; // The index of line in the .txt content
    public float textSpeed;


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
        lineFinished = true;
        StartCoroutine(SetTextUI());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && lineFinished)
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
        textLable.text = "";

        switch(textList[index].Trim().ToString())
        {
            case  "A":
                face02.SetActive(false);
                face01.SetActive(true);
                index++;
                break;
            case "B":
                face01.SetActive(false);
                face02.SetActive(true);
                index++;
                break;
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLable.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        lineFinished = true;
        index++; 
    }
}

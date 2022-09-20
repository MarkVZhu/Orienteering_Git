using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPrompt : MonoBehaviour
{
    public string keyword1;
    public string keyword2;
    public GameObject prompt1;
    public GameObject prompt2;

    // Start is called before the first frame update
    void Update()
    {
        if (this.GetComponent<Text>().text.Contains(keyword1))
        {
            prompt2.SetActive(false);
            prompt1.SetActive(true);
        }
        else if (this.GetComponent<Text>().text.Contains(keyword2))
        {
            prompt1.SetActive(false);
            prompt2.SetActive(true);
        }
        else if(prompt1.activeInHierarchy || prompt2.activeInHierarchy)
        {
            prompt1.SetActive(false);
            prompt2.SetActive(false);
        }
    }
}

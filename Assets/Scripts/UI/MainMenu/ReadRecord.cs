using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadRecord : MonoBehaviour
{
    public int levelNum;

    // Start is called before the first frame update
    void Start()
    {
        float record = LoadData.instance.GetLevelRecord()[levelNum - 1];
        if(record != 0)
        {
            this.GetComponent<Text>().text = "Best: " + Timer.ToTimeFormat(record);
        }
    }
}

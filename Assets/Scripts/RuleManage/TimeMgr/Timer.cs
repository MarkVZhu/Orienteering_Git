using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    string name;
    public Timer(string name)
    {
        this.name = name;
    }

    bool isRecording = false;
    float startTime;

    public void StartRecording()
    {
        isRecording = true;
        startTime = Time.time;
    }

    public float GetCurrentRecord()
    {
        if (isRecording)
        {
            float deltaTime = Time.time - startTime;
            return deltaTime;
        }
        else return 0;
    }

    public void Reset()
    {
        isRecording = false;
        startTime = 0;
    }

    //Change float time into the actual time format 
    public static string ToTimeFormat(float time)
    {
        int tenMs = (int)(time * 100 % 100);
        int seconds = (int)time;
        int min = seconds % 3600 / 60;
        seconds = seconds % 3600 % 60;
        return string.Format("{0:D2}:{1:D2}:{2:D2}", min, seconds, tenMs);
    }
}
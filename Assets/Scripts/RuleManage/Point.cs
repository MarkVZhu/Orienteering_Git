using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point 
{
    private string pointName;
    private float arrivalTime;
    private int order; 

    public  Point(string name, int order)
    {
        this.pointName = name;
        this.order = order;
        this.arrivalTime = -1; 
    }

    public void SetName(string name)
    {
        this.pointName = name;
    }

    public string GetName()
    {
        return pointName;
    }

    public int GetOrder()
    {
        return order;
    }

    public void SetTime(float arrivalTime)
    {
        this.arrivalTime = arrivalTime;
    }

    public float  GetArrivalTime()
    {
        return arrivalTime;
    }
}

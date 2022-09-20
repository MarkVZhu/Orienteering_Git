using System.Collections;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public GameObject pointParent;
    public Point[] pointsArray;
    public float[] timeArrayForPoints;
    public static RuleManager ruleInstance;

    private void Awake()
    {
        ruleInstance = this;
    }

    // Use this for initialization
    void Start()
    {
        //Initialize pointsArray with specific lenght
        Transform pointsTransform = pointParent.transform;
        pointsArray = new Point[pointsTransform.childCount];
        timeArrayForPoints = new float[pointsTransform.childCount];

        //Assign points into the array 
        for (int i = 0; i < pointsTransform.childCount; i++)
        {
            pointsArray[i] = new Point(pointsTransform.GetChild(i).name, i + 1);
        }
    }

    /*private void Update()
    {
        Debug.Log(timeArrayForPoints[0] + "," + timeArrayForPoints[1] + "," + timeArrayForPoints[2]);
    }*/
}
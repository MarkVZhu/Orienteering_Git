using UnityEngine;
using System.Collections;


public class Compass : MonoBehaviour
{
    private float zRotation = 5.0F;
    private GameObject obj;


    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        zRotation = obj.transform.eulerAngles.y;
        transform.eulerAngles = new Vector3(0, 0, zRotation);
    }
}
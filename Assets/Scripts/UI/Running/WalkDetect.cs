using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDetect : MonoBehaviour
{
    public GameObject LoadManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && LoadManager.GetComponent<LoadManager>().GetCanShowLoadScreen())
        {
            LoadManager.GetComponent<LoadManager>().LoadLevel ();
        }
    }
}

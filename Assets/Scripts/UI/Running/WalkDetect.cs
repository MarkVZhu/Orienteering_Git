using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDetect : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && LoadManager.Instance.GetCanShowLoadScreen())
        {
            LoadManager.Instance.LoadLevel ();
        }
    }
}

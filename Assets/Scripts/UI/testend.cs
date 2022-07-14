using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testend : MonoBehaviour
{
    public GameObject LoadManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            LoadManager.GetComponent<LoadManager>().LoadNextLevel();
        }
    }

}

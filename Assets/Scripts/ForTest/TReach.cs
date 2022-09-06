using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TReach : MonoBehaviour
{
    public GameObject reachText;
    public Material reachedColor;
    private bool reached = false;
    private bool canIn = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !reached)
        {
            reachText.SetActive(true);
            canIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            reachText.SetActive(false);
            canIn = false;
        }
    }

    private void Update()
    {
        if (reachText.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.E) && canIn)
            {
                this.GetComponent<MeshRenderer>().material = reachedColor;
                reached = true;
            }
        }
    }
}

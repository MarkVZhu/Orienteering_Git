using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDialogPanel : MonoBehaviour
{
    public GameObject targetPanel;
    // Start is called before the first frame update
    void Start()
    {
        targetPanel.SetActive(true);
    }
}

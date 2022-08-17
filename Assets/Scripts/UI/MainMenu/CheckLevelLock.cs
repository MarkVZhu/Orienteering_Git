using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLevelLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool[] levelLock = LoadData.instance.GetLevelLockInfor();

        for (int i = 0; i < levelLock.Length; i++)
        {
            if (levelLock[i])
            {
                foreach (Transform t in this.transform.GetComponentInChildren<Transform>())
                {
                    if (t.name.Equals("Button" + (i+1)))
                    {
                        t.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                foreach (Transform t in this.transform.GetComponentInChildren<Transform>())
                {
                    if (t.name.Equals("Button" + (i + 1) + "Not"))
                    {
                        t.gameObject.SetActive(true);
                    }
                }
            }
        }

    }

}

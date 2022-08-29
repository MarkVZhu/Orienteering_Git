using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepsForSeconds : MonoBehaviour
{
    public float time = 5f;
    private float count;

    // Start is called before the first frame update
    private void OnEnable()
    {
        count = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count += Time.deltaTime;
        if (count >= time)
            gameObject.SetActive(false);
    }
}

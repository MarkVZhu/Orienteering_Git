using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachUIToGameObject : MonoBehaviour
{
    public Transform targetTransform;
    [SerializeField] Camera UICamera, MainCamera;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GetScreenPosition(targetTransform);
    }

    public Vector3 GetScreenPosition(Transform targetTransform)
    {
        Vector3 offset = MainCamera.transform.position - UICamera.transform.position;
        Vector2 uiPos = targetTransform.position - offset;
        return uiPos;
    }
}

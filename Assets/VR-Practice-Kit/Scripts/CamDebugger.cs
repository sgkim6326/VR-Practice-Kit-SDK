using System;
using System.Collections.Generic;
using UnityEngine;

public class CamDebugger : MonoBehaviour
{
#if UNITY_EDITOR
    private float rotX;
#endif
    private void Update()
    {
#if UNITY_EDITOR
        float y = Input.GetAxis("Mouse X");
        rotX += Input.GetAxis("Mouse Y");
        rotX = Mathf.Clamp(rotX, -90, 90);
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
#endif
    }
}
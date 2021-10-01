using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class IMUTest : MonoBehaviour
{
    public Transform CalibrationSystem;
    void Update()
    {
        transform.localRotation = VRKitCore.GetRotation();
        if (VRKitCore.GetKeyDown())
        {
            CalibrationSystem.LookAt(Camera.main.transform.position - Camera.main.transform.right, - Camera.main.transform.up);
        }
    }
}




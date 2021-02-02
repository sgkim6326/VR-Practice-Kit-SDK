using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class IMUTest : MonoBehaviour
{
    void Update()
    {
        transform.localRotation = VRKitCore.GetRotation();
    }
}




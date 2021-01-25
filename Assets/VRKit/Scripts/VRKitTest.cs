using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class VRKitTest : MonoBehaviour
{
    void Update()
    {
        float input_vertical = VRKitCore.GetAxis("Vertical");
        float input_horizontal = VRKitCore.GetAxis("Horizontal");
        bool input_key = VRKitCore.GetKeyDown();
        Debug.Log(input_vertical + "," + input_horizontal + "," + input_key);
    }
}

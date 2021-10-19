using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class JoystickTest : MonoBehaviour
{
    Camera cam = null;
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        var input_vertical = VRKitCore.GetAxis("Vertical");
        var input_horizontal = VRKitCore.GetAxis("Horizontal");
        input_vertical = input_vertical * Time.deltaTime * 3;
        input_horizontal = input_horizontal * Time.deltaTime * 100;
        var dir = cam.transform.forward;
        dir.y = 0;
        transform.Translate(dir * input_vertical, Space.World);
        transform.Rotate(transform.up * input_horizontal);
    }
}




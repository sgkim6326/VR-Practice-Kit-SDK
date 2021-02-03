using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class JoystickTest : MonoBehaviour
{
    void Update()
    {
        var input_vertical = VRKitCore.GetAxis("Vertical");
        var input_horizontal = VRKitCore.GetAxis("Horizontal");

        var input_jump = VRKitCore.GetKeyDown();

        input_vertical = input_vertical * Time.deltaTime * 3;
        input_horizontal = input_horizontal * Time.deltaTime * 100;

        transform.Translate(transform.forward * input_vertical, Space.World);
        transform.Rotate(transform.up * input_horizontal);

        if (input_jump)
        {
            transform.Translate(transform.up);
        }
    }
}




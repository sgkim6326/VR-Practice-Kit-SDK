using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class KeyboardInteraction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        var input_vertical = VRKitCore.GetAxis("Vertical");
        var input_horizontal = VRKitCore.GetAxis("Horizontal");

        var input_jump = VRKitCore.GetKeyDown();

        input_vertical = input_vertical * Time.deltaTime;
        input_horizontal = input_horizontal * Time.deltaTime * 100;

        transform.Translate(Vector3.forward * input_vertical);
        transform.Rotate(Vector3.up * input_horizontal);

        if (input_jump)
        {
            transform.Translate(Vector3.up);
        }
    }
}




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRKit;

public class RemoteControllerTest : MonoBehaviour
{
    RaycastHit hit;
    int i = 0;
    void Update()
    {
        if (VRKitCore.GetKeyDown()
            && Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if(hit.transform.name == "Cube")
            {
                hit.transform.GetChild(0).GetComponent<TextMesh>().text = "버튼 클릭 횟수: " + ++i;
            }
        }
    }
}

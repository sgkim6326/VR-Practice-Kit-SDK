using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardDebug : MonoBehaviour
{
    public Button u, d, l, r, s;
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) u.interactable = false;
        else u.interactable = true;

        if (Input.GetKey(KeyCode.DownArrow)) d.interactable = false;
        else d.interactable = true;

        if (Input.GetKey(KeyCode.LeftArrow)) l.interactable = false;
        else l.interactable = true;

        if (Input.GetKey(KeyCode.RightArrow)) r.interactable = false;
        else r.interactable = true;

        if (Input.GetKey(KeyCode.Space)) s.interactable = false;
        else s.interactable = true;
    }
}

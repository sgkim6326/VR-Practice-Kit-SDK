using System;
using System.Collections.Generic;
using UnityEngine;

public class GrabManageModule: MonoBehaviour
{
    Transform currentGrabbedObject = null;
    Camera cam = null;
    bool havingGrabbableObject => transform.childCount != 0;
    private void Start()
    {
        cam = Camera.main;
    }
    private void Update()
    {
        if (VRKit.VRKitCore.GetKeyDown())
        {
            if (havingGrabbableObject)
            {
                currentGrabbedObject.GetComponent<Rigidbody>().isKinematic = false;
                foreach (var collider in currentGrabbedObject.GetComponentsInChildren<Collider>())
                    collider.enabled = true;
                currentGrabbedObject.parent = null;
            }
            else if (Physics.Raycast(cam.ViewportPointToRay(Vector2.one / 2f), out RaycastHit hittedInfo, float.MaxValue, 1 << LayerMask.NameToLayer("GrabbableObject")))
            {
                currentGrabbedObject = hittedInfo.transform;
                currentGrabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                foreach (var collider in currentGrabbedObject.GetComponentsInChildren<Collider>())
                    collider.enabled = false;
                currentGrabbedObject.parent = transform;
                currentGrabbedObject.localPosition = Vector3.zero;
                currentGrabbedObject.localRotation = Quaternion.identity;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (cam != null)
        {
            Ray ray = cam.ViewportPointToRay(Vector2.one / 2f);
            Gizmos.DrawRay(ray);
        }
    }
}
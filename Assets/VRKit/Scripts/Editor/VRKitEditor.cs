using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace VRKit
{
    [CustomEditor(typeof(VRKitCore)), CanEditMultipleObjects]
    public class VRKitEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            VRKitCore core = (VRKitCore)target;
            core.GetComponent<AudioSource>().hideFlags = HideFlags.HideInInspector;
            core.ConnectionFailedSound.hideFlags = HideFlags.HideInInspector;
            core.ConnectionSucessSound.hideFlags = HideFlags.HideInInspector;
            core.DisconnectedSound.hideFlags = HideFlags.HideInInspector;
            core.StartConnectionSound.hideFlags = HideFlags.HideInInspector;
        }
    }

}

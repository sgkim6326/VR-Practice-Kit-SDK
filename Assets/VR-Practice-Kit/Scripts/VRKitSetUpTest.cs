using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRKitSetUpTest : MonoBehaviour
{
    public InputField EnterVendorID;
    public Button LoadJoystickTest, LoadImuTest;
    public VRKit.VRKitCore VRKitManager;
    void Awake() => XRSettings.enabled = false;
    void Start()
    {
        LoadJoystickTest.onClick.AddListener(() =>
        {
            VRKitManager.deviceName = EnterVendorID.text;
            VRKitManager.gameObject.SetActive(true);
            XRSettings.enabled = true;
            SceneManager.LoadScene("Character-Control-Example");
        });
        LoadImuTest.onClick.AddListener(() =>
        {
            VRKitManager.deviceName = EnterVendorID.text;
            VRKitManager.gameObject.SetActive(true);
            XRSettings.enabled = true;
            SceneManager.LoadScene("UI-Control-Example");
        });
    }
}

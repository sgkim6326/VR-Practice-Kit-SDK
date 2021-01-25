
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;
using System;

namespace VRKit
{
    [RequireComponent(typeof(AudioSource))]
    public class VRKitCore : MonoBehaviour
    {
        public enum KitState
        {
            Connect, Ready, Failed
        }
        public string deviceName;

        public AudioClip StartConnectionSound, ConnectionSucessSound, ConnectionFailedSound, DisconnectedSound;

        [HideInInspector]
        public KitState State = KitState.Ready;

        static VRKitCore instance;
        BluetoothHelper bluetoothHelper;

        int JoyStick_X = 500, JoyStick_Y = 500, JoyStick_Click = 1;
        float MPU_X = 0f, MPU_Y = 0f, MPU_Z = 0f;

        AudioSource mAudioSource;

        void Awake() => mAudioSource = GetComponent<AudioSource>();

        void Start()
        {
            bluetoothHelper = BluetoothHelper.GetInstance(deviceName);
            bluetoothHelper.OnConnected += OnConnected;
            bluetoothHelper.OnConnectionFailed += OnConnectionFailed;
            bluetoothHelper.OnDataReceived += OnMessageReceived;
            bluetoothHelper.setTerminatorBasedStream("\n");
            Connect();
            DontDestroyOnLoad(gameObject);
        }

        void Connect()
        {
            if (mAudioSource == null) Debug.Log("오디오 소스 없음");
            if (StartConnectionSound != null)
            {
                mAudioSource.clip = StartConnectionSound;
                mAudioSource.Play();
            }
            State = KitState.Ready;
            try
            {
                LinkedList<BluetoothDevice> ds = bluetoothHelper.getPairedDevicesList();
                if (bluetoothHelper.isDevicePaired()) bluetoothHelper.Connect();
            }
            catch (Exception)
            {
                State = KitState.Failed;
                if (ConnectionFailedSound != null)
                {
                    mAudioSource.clip = ConnectionFailedSound;
                    mAudioSource.Play();

                }
            }
        }
        void OnMessageReceived()
        {
            try
            {
                string[] data = bluetoothHelper.Read().Split(',');
                if (data[0] == "s")
                {
                    JoyStick_X = int.Parse(data[1]);
                    JoyStick_Y = int.Parse(data[2]);
                    JoyStick_Click = int.Parse(data[3]);
                    MPU_X = float.Parse(data[4]);
                    MPU_Y = float.Parse(data[5]);
                    MPU_Z = float.Parse(data[6]);
                }
            }
            catch { }
        }
        void OnConnected()
        {
            State = KitState.Connect;
            try
            {
                bluetoothHelper.StartListening();
                if (ConnectionSucessSound != null)
                {
                    mAudioSource.clip = ConnectionSucessSound;
                    mAudioSource.Play();
                }
            }
            catch (Exception)
            {
                if (ConnectionFailedSound != null)
                {
                    mAudioSource.clip = ConnectionFailedSound;
                    mAudioSource.Play();
                }
            }
        }

        void OnConnectionFailed()
        {
            State = KitState.Failed;
            mAudioSource.clip = ConnectionFailedSound;
            mAudioSource.Play();
        }
        /// <summary>
        /// 조이스틱 버튼의 상태
        /// </summary>
        /// <returns></returns>
        public static bool GetKeyDown()
        {
            instance = FindObjectOfType<VRKitCore>();
            if (instance == null) return false;
            else return instance.getKeyDown();
        }
        /// <summary>
        /// 조이스틱 버튼의 동작 상태
        /// </summary>
        /// <param name="type">"Vertical" 또는 "Horizontal"을 통해 결정</param>
        /// <returns></returns>
        public static float GetAxis(string type)
        {
            instance = FindObjectOfType<VRKitCore>();
            if (instance == null) return 0.5f;
            else return instance.getAxis(type);
        }

        private bool getKeyDown()
        {
            if (JoyStick_Click == 0) return true;
            else return false;
        }
        private float getAxis(string type)
        {
            switch (type)
            {
                case "Vertical":
                    if (JoyStick_X > 300 && JoyStick_X < 700) return 0;
                    return (JoyStick_X-500) / 500f;
                case "Horizontal":
                    if (JoyStick_Y > 300 && JoyStick_Y < 700) return 0;
                    return (JoyStick_Y-500) / 500f;
                default:
                    return 0;
            }
        }

        private Quaternion GetRotationInfo()
        {
            return Quaternion.Euler(-MPU_X, -MPU_Y, MPU_Z);
        }

        void OnApplicationPause(bool pause)
        {
            if (pause) bluetoothHelper.Disconnect();
            else Connect();
        }

        void OnDestroy()
        {
            bluetoothHelper.Disconnect();
        }
    }
}

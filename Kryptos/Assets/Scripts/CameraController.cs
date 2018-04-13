using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    Camera mainCamera;
    public Camera otherCamera;
    public static bool isMainCameraActive = true;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        otherCamera.enabled = false;
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("isDecryptingCaesar") == 1 ||
            PlayerPrefs.GetInt("isDecryptingVigenere") == 1 ||
            PlayerPrefs.GetInt("isDecryptingRailFenceKey") == 1 ||
            PlayerPrefs.GetInt("isDecryptingRailFence") == 1) 
        {
            otherCamera.enabled = true;
            mainCamera.enabled = false;
            isMainCameraActive = false;
        }
        else
        {
            mainCamera.enabled = true;
            otherCamera.enabled = false;
            isMainCameraActive = true;
        }
    }
}

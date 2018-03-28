using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    Camera mainCamera;
    public Camera otherCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        otherCamera.enabled = false;
    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar ||
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere ||
            GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingRailFence) 
        {
            otherCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = true;
            otherCamera.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    Camera mainCamera;
    public Camera caesarCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        caesarCamera.enabled = false;
    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<FirstPersonController>().isDecrytping)
        {
            caesarCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = true;
            caesarCamera.enabled = false;
        }
    }
}

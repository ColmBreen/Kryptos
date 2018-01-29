using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    Camera mainCamera;
    public Camera caesarCamera;
    public Camera vigenereCamera;

    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.enabled = true;
        caesarCamera.enabled = false;
        vigenereCamera.enabled = false;
    }

    void Update()
    {
        if (GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingCaesar) 
        {
            caesarCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else if(GameObject.Find("Player").GetComponent<FirstPersonController>().isDecryptingVigenere)
        {
            vigenereCamera.enabled = true;
            mainCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = true;
            caesarCamera.enabled = false;
            vigenereCamera.enabled = false;
        }
    }
}

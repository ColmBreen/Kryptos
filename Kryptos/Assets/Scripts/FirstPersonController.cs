using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    public float jumpSpeed = 20;
    public bool isMenuActive = false;
    public bool isDecryptingCaesar = false;
    public bool isDecryptingVigenere = false;

    float verticalRotation = 0;
    public float upDownRange = 60.0f;

    float verticalVelocity = 0;

    CharacterController characterController;

    // Use this for initialization
    void Start ()
    {
        Screen.lockCursor = true;
        characterController = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!isMenuActive && !isDecryptingCaesar)
        {
            //Rotation
            float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, rotLeftRight, 0);

            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);

            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

            //movement
            float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            float sideSpeed = 0;
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;
            if (characterController.isGrounded)
            {
                if (Input.GetButton("Jump"))
                {
                    verticalVelocity = jumpSpeed;
                }
            }

            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

            speed = transform.rotation * speed;

            characterController.Move(speed * Time.deltaTime);
        }
    }
}

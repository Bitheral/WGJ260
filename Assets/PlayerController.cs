using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 1;
    public float mouseSensitivity = 100;

    private CharacterController controller;
    private Camera cam;
    
    public float clampAngle = 60;
    
    float xRotation = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void MoveCharacter()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
        move = transform.TransformDirection(move);
        move *= speed;
        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                
            }
        }
        move += (Physics.gravity * Time.deltaTime);
        controller.Move(move);
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 10;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 10;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -clampAngle, clampAngle);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up, mouseX);
    }
    
    void Update()
    {
        MoveCamera();
        MoveCharacter();
    }
}

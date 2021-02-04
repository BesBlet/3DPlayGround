using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MovementConfig")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("RotationConfig")]
    [SerializeField] private float rotationSpeed = 800f;

    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 2;
    [SerializeField] private float gravityScale = 1;
    float gravity;





    void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * inputV + transform.right * inputH;
        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        

        if(controller.isGrounded)
        {
            gravity = -0.1f;

            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpHeight;
            }
        }
        else
        {
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }

       
        moveDirection.y = gravity;

        controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [Header("Movement config")]
    [SerializeField] private float moveSpeed = 10f;

    [Header("Rotation config")]
    [SerializeField] private float rotationSpeed = 800f;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravityScale = 2;

    [Header("References")]
    [SerializeField] private CharacterController controller;


    private float gravity;
    private Vector3 startPosition;
    private bool isResetting;

    public void DoDamage()
    {
        ResetPosition();
    }

    private void ResetPosition()
    {
        StartCoroutine(ResetPositionCorutine());
    }
    IEnumerator ResetPositionCorutine()
    {
        isResetting = true;
        transform.position = startPosition;
        yield return new WaitForSeconds(0.1f);
        isResetting = false;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Awake()
    {
        if (Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (isResetting)
        {
            return;
        }

        Rotate();
        Move();
    }

    void Move()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * inputV + transform.right * inputH;

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        if (controller.isGrounded)
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

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        float mouseHorizontal = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, mouseHorizontal * rotationSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10;

    [SerializeField]
    private float rotationSpeed = 10;

    [SerializeField]
    private float jumpForce = 400;

    [SerializeField]
    private GameObject objectsCenter;


    [SerializeField]
    private float objectsRadius = 1f;

    [SerializeField]
    private float maxPushForce = 1f;

    [SerializeField]
    private float pushHeight = 5f;

    [SerializeField]
    private LayerMask objectsMask;

    [SerializeField]
    private int forceUpSpeed = 1; 



    Rigidbody rb;

    float pushForce;
    bool isGoingUp;

    float time;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetMouseButtonDown(0))
        {
            pushForce = 0;
            isGoingUp = true;
            time = 0;
        }

        if (Input.GetMouseButton(0))
        {
            /*if(isGoingUp)
            {
                pushForce += maxPushForce * Time.deltaTime;

                if(pushForce >= maxPushForce)
                {
                    isGoingUp = false;
                }
            }
            else
            {
                pushForce -= maxPushForce * Time.deltaTime;
                if (pushForce <= maxPushForce)
                {
                    isGoingUp = true;
                }
            }*/

            time += Time.deltaTime;
          
            print("sin " + pushForce);

        

        }

        print("pushf" + pushForce);

        if (Input.GetMouseButtonUp(0))
        {
            Collider[] colliders = Physics.OverlapSphere(objectsCenter.transform.position, objectsRadius, objectsMask);

            foreach(Collider col in colliders)
            {
                Rigidbody colRb = col.GetComponent<Rigidbody>();

                Vector3 forceDirection = transform.forward;
                forceDirection.y = pushHeight;
                pushForce = ((1 / forceUpSpeed + Mathf.Sin(time)) / 2 * maxPushForce);
                colRb.AddForce(forceDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }
    }
    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        //rb.velocity = transform.forward * inputVertical * speed;
        rb.AddForce(transform.forward * inputVertical * speed);

        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * rotationSpeed);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(objectsCenter.transform.position, objectsRadius);
    }
}
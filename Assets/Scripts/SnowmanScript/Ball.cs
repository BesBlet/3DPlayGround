using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void ResetPosition ()
    {
        transform.position = new Vector3(0, 10, 0);
        rb.velocity = Vector3.zero;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ResetPosition();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetPosition();
        }
    }



}

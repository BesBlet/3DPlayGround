using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationDoor : MonoBehaviour
{
    /*[SerializeField] private GameObject[] teleportDoors;*/
    [SerializeField] private Collider teleportDoors1;
    [SerializeField] private Collider teleportDoors2;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            print("triggered");
            PlayerMovement.Instance.transform.position = teleportDoors1.transform.position;
        }

        
    }
    
}

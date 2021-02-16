using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TeleportationDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] teleportDoors;
   /* [SerializeField] private Collider teleportDoors1;
    [SerializeField] private Collider teleportDoors2;*/

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("triggered");

            Vector3 doorPosition = teleportDoors[0].transform.position;
           
            PlayerMovement.Instance.transform.DOMove(doorPosition, 1f);

        }

        
    }
    
}

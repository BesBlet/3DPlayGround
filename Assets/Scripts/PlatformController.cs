using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlatformController : MonoBehaviour
{
    
    [SerializeField] float startZ;
    [SerializeField] float endZ;

    [SerializeField] float upTime = 4f;
    [SerializeField] float downTime = 3f;

    [SerializeField] float upDelay = 1f;
    [SerializeField] float downDelay = 1f;
    bool isActive;

    [SerializeField] AnimationCurve movementEase;

   
    public void PlatformActivate()
    { 
        if (isActive)
        {
            return;
        }

        Vector3 newPos = transform.position;
        newPos.z = startZ;
        transform.position = newPos;


        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveZ(endZ, upTime).SetEase(movementEase));
        moveSequence.AppendInterval(upDelay);
        moveSequence.Append(transform.DOMoveZ(startZ, downTime));
        moveSequence.AppendInterval(downDelay);
        moveSequence.SetLoops(-1);
        moveSequence.SetUpdate(UpdateType.Fixed);
        isActive = true;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            other.transform.SetParent(transform);
               
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }

    }
}

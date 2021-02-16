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

    [SerializeField] AnimationCurve movementEase;


    public void PlatformActivate()
    { 
        Vector3 newPos = transform.position;
        newPos.z = startZ;
        transform.position = newPos;


        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveZ(endZ, upTime).SetEase(movementEase));
        moveSequence.AppendInterval(upDelay);
        moveSequence.Append(transform.DOMoveZ(startZ, downTime));
        moveSequence.AppendInterval(downDelay);
        moveSequence.SetLoops(-1);
    }
}

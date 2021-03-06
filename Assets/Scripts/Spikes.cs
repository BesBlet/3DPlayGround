﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spikes : MonoBehaviour
{
    [SerializeField] float downY;
    [SerializeField] float upY;

    [SerializeField] float upTime = 10f;
    [SerializeField] float downTime = 3f;

    [SerializeField] float upDelay = 1f;
    [SerializeField] float downDelay = 1f;

    [SerializeField] AnimationCurve movementEase;




    void Start()
    {
        Vector3 newPos = transform.position;
        newPos.y = downY;
        transform.position = newPos;


        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveY(upY, upTime).SetEase(movementEase));
        moveSequence.AppendInterval(upDelay);
        moveSequence.Append(transform.DOMoveY(downY, downTime));
        moveSequence.AppendInterval(downDelay);
        moveSequence.SetLoops(-1);

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.Instance.DoDamage();
        }
    }
}

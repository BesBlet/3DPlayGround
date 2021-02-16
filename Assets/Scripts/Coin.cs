using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinSpeedRotation = 100f;

    private void Start()
    {
        LevelManager.Instance.CoinAddValue();
    }

    private void Update()
    {
        CoinRotation();
    }

    void CoinRotation ()
    {
        transform.Rotate(Vector3.right, coinSpeedRotation * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            LevelManager.Instance.CoinTakeAwayValue();
        }
    }
}

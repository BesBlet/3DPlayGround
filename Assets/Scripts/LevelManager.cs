using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager Instance { get; private set; }

   [SerializeField] private int coinValue;

   [SerializeField] private GameObject portal;

   private void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
         return;
      }

      Instance = this;
   }

   private void Start()
   {
      DontDestroyOnLoad(gameObject);
   }

   public void CoinAddValue()
   {
      coinValue++;
   }

   public void CoinTakeAwayValue()
   {
      coinValue--;
      if (coinValue <= 0)
      {
         PortalActivate();
      }
   }

   void PortalActivate()
   {
      portal.SetActive(true);
   }
}

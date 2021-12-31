using System;
using System.Collections;
using PowerUps.Types;
using UnityEngine;

namespace coins
{
    public class CoinManager : MonoBehaviour
    {
        public static CoinManager Instance;
        private int _coins = 0;
        public event EventHandler<int> coinsChanged;
        private int multiplier = 1;
        float boostTime = 10;

        public int coins
        {
            get => _coins;
            set
            {
                _coins = value;
                coinsChanged?.Invoke(this, _coins);
            }
        }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            monedas.monedaRecodiga += AddCoin;
            PointsX2.ptsx2Event += HandleX2Boost;
        }

        private void OnDestroy()
        {
            monedas.monedaRecodiga -= AddCoin;
            PointsX2.ptsx2Event -= HandleX2Boost;
        }

        private void HandleX2Boost()
        {
            multiplier *= 2;
            StartCoroutine(ReturnToNormal());
        }

        private IEnumerator ReturnToNormal()
        {
            yield return new WaitForSeconds(boostTime);
            multiplier /= 2;
        }

        private void AddCoin()
        {
            coins += multiplier;
            // Debug.Log("Coins: " + _coins);
        }
    }
}
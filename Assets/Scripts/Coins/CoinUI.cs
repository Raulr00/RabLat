using System;
using TMPro;
using UnityEngine;

namespace coins
{
    public class CoinUI : MonoBehaviour
    {
        public TextMeshProUGUI coinText;
        private void Awake()
        {
            CoinManager.Instance.coinsChanged += HandleCoins;
        }

        private void HandleCoins(object sender, int e)
        {
            coinText.text = e.ToString();
        }
    }
}
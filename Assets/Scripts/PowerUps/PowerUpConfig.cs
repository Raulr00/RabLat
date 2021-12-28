using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    [CreateAssetMenu(menuName = "Custom/PowerUp/PowerUpConfig")]
    public class PowerUpConfig : ScriptableObject  
    {
        [SerializeField]public PowerUp[] powerUps;
        public string[] ids;
        private Dictionary<string, PowerUp> IdToPwrUp;

        private void Awake()
        {
            ids = new string[powerUps.Length];
            IdToPwrUp = new Dictionary<string, PowerUp>(powerUps.Length);

            for (int i = 0; i < powerUps.Length; i++)
            {
                ids[i] = powerUps[i].id;
                IdToPwrUp.Add(powerUps[i].id, powerUps[i]);
            }
        }

        public PowerUp GetPowerUpPrefab(string id)
        {
            if (!IdToPwrUp.TryGetValue(id, out var powerUpPrefab))
            {
                Debug.LogError("No matching powerUp for Id <{id}> introduced");
                return null;
            }

            return powerUpPrefab;
        }
    }
}
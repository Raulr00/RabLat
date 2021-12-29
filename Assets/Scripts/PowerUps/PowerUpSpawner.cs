using System;
using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

public class PowerUpSpawner : MonoBehaviour
{
    private Random _random = new Random();
    [SerializeField] public PowerUpConfig powerUpConfig;
    [SerializeField] public float spawnRate = 70;

    private void Awake()
    {
        int rand = _random.Next(101);
     /*   Debug.Log(rand + "\n"+
                  (rand > spawnRate));*/
        if (rand > spawnRate)
            return;
        
        powerUpConfig = Instantiate(powerUpConfig);

        rand = _random.Next(powerUpConfig.ids.Length);
        Object.Instantiate(powerUpConfig.GetPowerUpPrefab(powerUpConfig.ids[rand]), transform.position, Quaternion.identity);
        Debug.Log(powerUpConfig.ids[rand] + " instantiated");
        gameObject.SetActive(false);

    }
}
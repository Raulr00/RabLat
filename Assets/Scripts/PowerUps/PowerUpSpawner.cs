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
    private bool _spawnable = false;
    public bool forceSpawn = false;

    public bool spawnable
    {
        get => _spawnable;
        set
        {
            _spawnable = value;
            HandleSpawner();
        }
    }

    private void HandleSpawner()
    {
        if(!_spawnable) 
            return;

        int rand = _random.Next(101);
        /*   Debug.Log(rand + "\n"+
                     (rand > spawnRate));*/
        if (rand > spawnRate)
            return;
        
        
        powerUpConfig = Instantiate(powerUpConfig);

        rand = _random.Next(powerUpConfig.ids.Length);
        Object.Instantiate(powerUpConfig.GetPowerUpPrefab(powerUpConfig.ids[rand]), transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        spawnEvent?.Invoke();
    }

    public static event PowerUp.PowerUpEvent spawnEvent;

    private void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
        if (forceSpawn)
        {
            _spawnable = true;
            HandleSpawner();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;

    [SerializeField] private bool canSpawn;

    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;

    [SerializeField] private float entitiesSpeed = 7;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTimerMax = 0.5f;

    [SerializeField] private float scalingMultiplier = 1.0001f;
    [SerializeField] private float scaledSpawnTimerMax = 0.5f;
    [SerializeField] private float scaledEntitiesSpeed;
    private bool maxVelocityReached;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!canSpawn)
        {
            return;
        }
        TrySpawn();
        IncreaseSpeed();
    }

    private void TrySpawn()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            SpawnEntity();
        }
    }

    public void StartScript()
    {
        canSpawn = true;
        spawnTimer = spawnTimerMax;
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = entitiesPrefabs[Random.Range(0, entitiesPrefabs.Length)];

        int[] numbers = new int[] { -3, 0, 3 };
        var random = new System.Random();
        int randomIndex = random.Next(numbers.Length);
        int result = numbers[randomIndex];
        spawnPosition.x = result;

        
        GameObject spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
        spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed); 
    }

    private void IncreaseSpeed()
    {
        if (maxVelocityReached || Time.frameCount % 5 != 0 || Time.timeScale == 0)
        {
            return;
        }

        if (spawnTimerMax > scaledSpawnTimerMax)
        {
            spawnTimerMax /= scalingMultiplier;
        }
        else
        {
            spawnTimerMax = scaledSpawnTimerMax;
        }

        if (entitiesSpeed < scaledEntitiesSpeed)
        {
            entitiesSpeed *= scalingMultiplier;
        }
        else
        {
            entitiesSpeed = scaledEntitiesSpeed;
        }

        if (spawnTimerMax == scaledSpawnTimerMax && entitiesSpeed == scaledEntitiesSpeed)
        {
            maxVelocityReached = true;
        }

        GameObject[] entitiesInGame = GameObject.FindGameObjectsWithTag("Entity");
        foreach (GameObject e in entitiesInGame)
        {
            e.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
        }
    }
}

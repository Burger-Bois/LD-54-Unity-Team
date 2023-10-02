using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class SpawnManager : MonoBehaviour
{
    // spawn manager has list of spawn points
    // chooses spawn point to spawn gem
    [SerializeField] private SpawnPoint spawnPoint1,
        spawnPoint2,
        spawnPoint3,
        spawnPoint4,
        spawnPoint5,
        spawnPoint6,
        spawnPoint7,
        spawnPoint8,
        spawnPoint9,
        spawnPoint10,
        spawnPoint11;

    [SerializeField] private GameObject rock, ruby, emerald, amethyst, diamond, topaz, doubleScoreBonus;

    private List<SpawnPoint> spawnPoints = new ();
    private List<GameObject> spawnableObjects = new();

    private void Awake()
    {
        spawnPoints.Add(spawnPoint1);
        spawnPoints.Add(spawnPoint2);
        spawnPoints.Add(spawnPoint3);
        spawnPoints.Add(spawnPoint4);
        spawnPoints.Add(spawnPoint5);
        spawnPoints.Add(spawnPoint6);
        spawnPoints.Add(spawnPoint7);
        spawnPoints.Add(spawnPoint8);
        spawnPoints.Add(spawnPoint9);
        spawnPoints.Add(spawnPoint10);
        spawnPoints.Add(spawnPoint11);
        
        spawnableObjects.Add(rock);
        spawnableObjects.Add(topaz);
        spawnableObjects.Add(amethyst);
        spawnableObjects.Add(emerald);
        spawnableObjects.Add(ruby);
        spawnableObjects.Add(diamond);
        spawnableObjects.Add(doubleScoreBonus);
        
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Random rand = new Random();

        var spawnPosInital = new Vector3(0, 0, 0);

        for (int i = 0; i <= 1; i++)
        {
            var spawnPos = spawnPoints[rand.Next(0, 11)].transform.position;

            if (spawnPos == spawnPosInital)
            {
                break;
            }

            spawnPosInital = spawnPos;
        
            var itemToSpawn = GetItemToSpawn(rand.Next(0, 1000));
        
            itemToSpawn.transform.position = spawnPos;

            Instantiate(itemToSpawn);
        }
    }

    private GameObject GetItemToSpawn(int number)
    {

        if (number <= 20)
        {
            return spawnableObjects[6];
        }
        if (number <= 650)
        {
            return spawnableObjects[0];
        }
        if (number <= 800)
        {
            return spawnableObjects[1];
        }
        if (number <= 875)
        {
            return spawnableObjects[2];
        }
        if (number <= 925)
        {
            return spawnableObjects[3];
        }
        if (number <= 970)
        {
            return spawnableObjects[4];
        }
        return spawnableObjects[5];
    }
}

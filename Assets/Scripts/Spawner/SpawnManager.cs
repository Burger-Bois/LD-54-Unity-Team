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

    [SerializeField] private GameObject rock, ruby;

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
        spawnableObjects.Add(ruby);
    }

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Random rand = new Random();

        var spawnPos = spawnPoints[rand.Next(0, 10)].transform.position;

        var itemToSpawn = spawnableObjects[rand.Next(0, spawnableObjects.Count)];
        
        itemToSpawn.transform.position = spawnPos;

        Instantiate(itemToSpawn);
    }
}

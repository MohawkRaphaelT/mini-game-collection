using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject asteroids;

    public Transform[] spawnLocations;

    public int asteroidsLimit = 5;

    public List<GameObject> spawnedAsteroids = new List<GameObject>();

    private void Start()
    {
        InvokeRepeating(nameof(enemySpawn), 0f, 3f);
    }
    void Update()
    {
        enemySpawn();
    }
    void enemySpawn()
    {
        spawnedAsteroids.RemoveAll(asteroids => asteroids == null);

        if(spawnedAsteroids.Count >= asteroidsLimit)
        {
            return;
        }

        int randomSpawnChoice = Random.Range(0, spawnLocations.Length);

        GameObject newAsteroids = Instantiate(asteroids, spawnLocations[randomSpawnChoice].position, spawnLocations[randomSpawnChoice].rotation);

        spawnedAsteroids.Add(newAsteroids);
    }
}

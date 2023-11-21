using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<Enemy> enemies = new List<Enemy>();
    public Transform[] spawnLocation;

    public int currentWave;
    public int waveDuration;

    private int waveValue;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;

    void Start()
    {
        GenerateWave();
    }

    void FixedUpdate()
    {
        if(spawnTimer < 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                RandomizeSpawnLocation();

                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0;
                currentWave += 1;
                waveDuration += 10;
                GenerateWave();
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while(waveValue > 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if(waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if(waveValue<=0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    public void RandomizeSpawnLocation()
    {
        int randEnemy = Random.Range(0, enemiesToSpawn.Count);
        int randSpawnLocation = Random.Range(0, spawnLocation.Length);

        Instantiate(enemiesToSpawn[randEnemy], spawnLocation[randSpawnLocation].position, Quaternion.identity);
    }
}

[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}

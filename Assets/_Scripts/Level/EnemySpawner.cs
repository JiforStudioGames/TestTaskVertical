using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnIntervalMax;
    [SerializeField] private float spawnIntervalMin;
    
    public static List<IEnemyFactory> EnemyFactories = new List<IEnemyFactory>();
    
    private void OnEnable()
    {
        LevelManager.OnLoadLevel += StartSpawn;
    }

    private void OnDisable()
    {
        LevelManager.OnLoadLevel -= StartSpawn;
    }
    
    private void StartSpawn()
    {
        Debug.Log(LevelManager.CountEnemySpawned);
        LevelManager.OnEnemyStartSpawned?.Invoke(LevelManager.CountEnemySpawned);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (LevelManager.CountEnemySpawned > 0)
        {
            if (EnemyFactories.Count > 0)
            {
                int randomIndex = Random.Range(0, EnemyFactories.Count);
                var enemyFactory = EnemyFactories[randomIndex];
                
                var enemy = enemyFactory.CreateEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)].position);
                enemy.onDead += LevelManager.DeadEnemy;
                LevelManager.CountEnemySpawned--;
            }
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }
}

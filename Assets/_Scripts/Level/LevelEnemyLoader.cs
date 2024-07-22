using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class LevelEnemyLoader : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    private void OnEnable()
    {
        LevelManager.OnLoadLevel += LoadEnemy;
    }

    private void OnDisable()
    {
        LevelManager.OnLoadLevel -= LoadEnemy;
    }

    private void LoadEnemy()
    {
        foreach (var enemyPrefab in enemyPrefabs)
        {
            switch (enemyPrefab.enemyType)
            {
                case EnemyType.BaseEnemy:
                    EnemySpawner.EnemyFactories.Add(new BaseEnemyFactory(enemyPrefab));
                    break;
                case EnemyType.EmptyEnemy:
                    EnemySpawner.EnemyFactories.Add(new EmptyEnemyFactory(enemyPrefab));
                    break;
            }

        }
    }
    
    
}

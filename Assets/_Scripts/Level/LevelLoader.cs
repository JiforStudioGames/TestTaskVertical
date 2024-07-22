using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int hpLevel;
    
    [SerializeField] private int enemyCountMin;
    [SerializeField] private int enemyCountMax;
    
    private void Start()
    {
        LevelManager.LoadLevel(hpLevel, enemyCountMin, enemyCountMax);
    }
}

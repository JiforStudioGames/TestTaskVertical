using System;

public static class LevelManager
{
    public static int HpLevel;
    public static int CurrentHpLevel;
    
    public static int CountEnemySpawned;
    public static int CountEnemyRemaining;

    public static Action OnLoadLevel;
    public static Action<int> OnHpChange;
    public static Action OnCompleteGame;
    
    public static Action<int> OnEnemyStartSpawned;
    public static Action<int> OnEnemyDead;

    public static void LoadLevel(int hp, int enemyCountMin, int enemyCountMax)
    {
        HpLevel = hp;
        CurrentHpLevel = hp;
        CountEnemySpawned = UnityEngine.Random.Range(enemyCountMin, enemyCountMax);
        CountEnemyRemaining = CountEnemySpawned;
        
        OnLoadLevel?.Invoke();
    }

    public static void ChangeHp(int changeHp)
    {
        CurrentHpLevel += changeHp;

        if (CurrentHpLevel <= 0)
        {
            OnCompleteGame?.Invoke();
            return;
        }
        
        OnHpChange?.Invoke(CurrentHpLevel);
    }

    public static void DeadEnemy()
    {
        CountEnemyRemaining--;
        OnEnemyDead?.Invoke(CountEnemyRemaining);
    }
}

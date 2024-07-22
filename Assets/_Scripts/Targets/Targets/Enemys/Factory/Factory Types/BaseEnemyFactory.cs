using Unity.Mathematics;
using UnityEngine;

public class BaseEnemyFactory : IEnemyFactory
{
    private readonly Enemy _baseEnemyPrefab;

    public BaseEnemyFactory(Enemy prefab)
    {
        _baseEnemyPrefab = prefab;
    }

    public Enemy CreateEnemy(Vector2 position)
    {
        return Object.Instantiate(_baseEnemyPrefab, position, quaternion.identity);
    }
    
}

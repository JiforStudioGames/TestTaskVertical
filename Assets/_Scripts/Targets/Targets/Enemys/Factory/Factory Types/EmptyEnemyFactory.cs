using UnityEngine;

public class EmptyEnemyFactory : IEnemyFactory
{
    private readonly Enemy _emptyEnemyPrefab;

    public EmptyEnemyFactory(Enemy prefab)
    {
        _emptyEnemyPrefab = prefab;
    }

    public Enemy CreateEnemy(Vector2 position)
    {
        return Object.Instantiate(_emptyEnemyPrefab, position, Quaternion.identity);
    }
}

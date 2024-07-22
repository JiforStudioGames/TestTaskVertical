using UnityEngine;

public interface IEnemyFactory
{
    Enemy CreateEnemy(Vector2 position);
}

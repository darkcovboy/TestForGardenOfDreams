using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "EnemyFactory/Factory")]
public class EnemyFactoryData : ScriptableObject
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField, Min(1)] private int _enemyCount;
    [SerializeField, Min(1)] private int _leftRange;
    [SerializeField, Min(1)] private int _rightRange;

    public Enemy EnemyPrefab => _enemyPrefab;
    public int EnemyCount => _enemyCount;
    public int LeftRange => _leftRange;
    public int RightRange => _rightRange;
}

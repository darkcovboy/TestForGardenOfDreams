using UnityEngine;

[CreateAssetMenu(fileName = "GameplaySceneContainer", menuName = "PrefabContainer/GameplayScene")]
public class GameplaySceneContainer : ScriptableObject
{ 
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private EnemySpawner _enemySpawner;


    public Player PlayerPrefab => _playerPrefab;
    public EnemySpawner EnemySpawner => _enemySpawner;  
}

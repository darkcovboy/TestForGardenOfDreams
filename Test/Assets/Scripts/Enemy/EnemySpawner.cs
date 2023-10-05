using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class EnemySpawner : MonoBehaviour, IGameEndHandler
{
    private EnemyFactory _factory;

    private List<Enemy> _enemies;

    public event UnityAction OnGameEnd;

    [Inject]
    private void Constructor(EnemyFactory enemyFactory)
    {
        _factory = enemyFactory;
    }

    private void Start()
    {
        _enemies = _factory.Spawn();

        foreach (var enemy in _enemies)
        {
            enemy.OnDiyng += RemoveFromList;
        }
    }

    private void RemoveFromList(Enemy enemy)
    {
        _enemies.Remove(enemy);

        if(_enemies.Count <= 0)
        {
            OnGameEnd?.Invoke();
        }
    }
}

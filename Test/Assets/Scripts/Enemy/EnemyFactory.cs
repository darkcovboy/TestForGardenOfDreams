using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class EnemyFactory : IObjectFactory<Enemy> 
{
    private EnemyFactoryData _data;
    private Transform _position;
    private DiContainer _container;

    public EnemyFactory(DiContainer diContainer, EnemyFactoryData data, Transform mainStart)
    {
        _data = data;
        _position = mainStart;
        _container = diContainer;
    }

    public Enemy Create(Vector2 position)
    {
        return _container.InstantiatePrefabForComponent<Enemy>(_data.EnemyPrefab, position, Quaternion.identity, null);
    }

    public List<Enemy> Spawn()
    {
        List<Enemy> list = new List<Enemy>();

        for (int i = 0; i < _data.EnemyCount; i++)
        {
            float randomX = Random.Range(_position.position.x - _data.LeftRange, _position.position.x + _data.RightRange);
            Vector2 currentPosition = new Vector2(randomX, _position.position.y);

            list.Add(Create(currentPosition));
        }

        return list;
    }
}

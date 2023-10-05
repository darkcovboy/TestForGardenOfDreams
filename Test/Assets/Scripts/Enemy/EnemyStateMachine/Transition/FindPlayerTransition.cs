using UnityEngine;

public class FindPlayerTransition : EnemyTransition
{
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if(_playerDetector.IsPlayerFounded)
        {
            NeedTransit = true;
            _enemy.Player = _playerDetector.Player;
        }
    }
}

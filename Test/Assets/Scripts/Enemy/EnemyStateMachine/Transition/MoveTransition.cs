using UnityEngine;

public class MoveTransition : EnemyTransition
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _distance;

    private void Update()
    {
        if(Vector2.Distance(_enemy.transform.position, _enemy.Player.transform.position) < _distance)
        {
            NeedTransit = true;
        }
    }
}

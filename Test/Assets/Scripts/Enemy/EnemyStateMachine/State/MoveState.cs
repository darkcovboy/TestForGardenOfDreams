using UnityEngine;

public class MoveState : EnemyState
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if (_enemy.Player == null)
            return;

        Vector2 direction = _enemy.Player.transform.position - transform.position;
        transform.Translate(direction.normalized * _enemy.EnemyData.Speed *Time.deltaTime, Space.World);
    }
}

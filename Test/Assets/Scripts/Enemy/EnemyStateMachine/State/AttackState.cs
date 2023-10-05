using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyState
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        StartCoroutine(AttackPlayer());
    }

    private IEnumerator AttackPlayer()
    {
        while (_enemy.Player != null && _enemy.Player.CurrentHealth > 0)
        {
            _enemy.Player.ApplyDamage(_enemy.EnemyData.Damage);

            yield return new WaitForSeconds(_enemy.EnemyData.AttackDelay);
        }
    }
}

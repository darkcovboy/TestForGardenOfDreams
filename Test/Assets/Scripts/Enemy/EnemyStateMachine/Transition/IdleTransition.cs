using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTransition : EnemyTransition
{
    [SerializeField] private Enemy _enemy;

    private void Update()
    {
        if (_enemy.Player == null || _enemy.Player.CurrentHealth < 0)
            NeedTransit = true;
    }
}

using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyDetector : MonoBehaviour
{
    public bool IsEnemyInArea { get; private set; }

    private Enemy _lastEnemy;

    private void Start()
    {
        IsEnemyInArea = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            IsEnemyInArea = true;
            _lastEnemy = enemy;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            ResetEnemy();
        }
    }

    private void Update()
    {
        if(_lastEnemy != null && _lastEnemy.IsDied)
        {
            ResetEnemy();
        }
    }

    private void ResetEnemy()
    {
        IsEnemyInArea = false;
        _lastEnemy = null;
    }
}

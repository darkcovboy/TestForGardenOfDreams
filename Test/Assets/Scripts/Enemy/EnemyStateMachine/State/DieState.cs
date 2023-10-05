using UnityEngine;

public class DieState : EnemyState
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        DropItem(_enemy.EnemyData.Item);
        _enemy.InvokeDiyng();
        Destroy(gameObject);
    }

    private void DropItem(Item item)
    {
        Instantiate(item, transform.position, Quaternion.identity, null);
    }
}

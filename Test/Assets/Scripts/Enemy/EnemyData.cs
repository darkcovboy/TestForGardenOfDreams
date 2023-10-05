using UnityEngine;

[CreateAssetMenu(menuName ="Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Item _item;

    public int MaxHealth => _maxHealth;
    public int Damage => _damage;
    public int Speed => _speed;
    public float AttackDelay => _attackDelay;
    public Item Item => _item;
}

using UnityEngine;
using System;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, IHealthChanged, IRemovable<Enemy>
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private HealthBar _healthBar;
    public bool IsDied => !gameObject.activeSelf;
    public EnemyData EnemyData => _enemyData;

    public int CurrentHealth => _currentHealth;

    public Player Player { get; set; }

    private int _maxHealth;
    private int _currentHealth;

    public event UnityAction<int, int> OnHealthChanged;
    public event Action<Enemy> OnDiyng;

    private void Start()
    {
        _healthBar.Constructor(this);
        UpdateHealth();
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException();

        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void InvokeDiyng()
    {
        OnDiyng?.Invoke(this);
    }

    private void UpdateHealth()
    {
        _currentHealth = EnemyData.MaxHealth;
        _maxHealth = EnemyData.MaxHealth;
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }


}

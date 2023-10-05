using System;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class Player : MonoBehaviour, IFollowed, IHealthChanged
{
    [SerializeField] private PlayerStartData _startData;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private HealthBar _healthBar;

    private int _maxHealth;
    private int _health;
    private Inventory _inventory;

    public Transform Body => transform;
    public Shooter Shooter => _shooter;
    public int CurrentHealth => _health;

    public event UnityAction<int, int> OnHealthChanged;

    [Inject]
    public void Constructor(Inventory inventory)
    {
        _inventory = inventory;
    }

    private void Start()
    {
        _healthBar.Constructor(this);
        InitializeHealth();
        InitializeWeapon();
    }

    public void ApplyDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentException();

        _health -= damage;
        OnHealthChanged?.Invoke(_health, _maxHealth);

        if(_health <= 0)
        {
            //Some logic to lose
            Destroy(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        _inventory.Add(item, item.Capacity);
    }

    private void InitializeHealth()
    {
        _maxHealth = _startData.MaxHealth;
        _health = _startData.StartHealth;
        OnHealthChanged?.Invoke(_health, _maxHealth);
    }

    private void InitializeWeapon()
    {
        if(_inventory.TryGet<Weapon>(out Weapon weapon))
        {
            Debug.Log("Оружие пришло");
            _shooter.InitializeWeapon(weapon);
        }
        else
        {
            Debug.Log("Оружие не пришло");
            _shooter.InitializeWeapon(null);
        }
        
    }
}

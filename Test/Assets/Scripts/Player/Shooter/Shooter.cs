using UnityEngine;
using Zenject;

public class Shooter : MonoBehaviour, IShootable
{
    [SerializeField] private SkinRotator _skinRotator;
    [SerializeField] private Transform _weaponPosition;
    [SerializeField] private EnemyDetector _enemyDetector;

    private Weapon _currentWeapon;
    private Inventory _currentInventory;

    public bool CanShoot { get => _enemyDetector.IsEnemyInArea; }

    [Inject]
    public void Constructor(Inventory inventory)
    {
        _currentInventory = inventory;
    }

    public void InitializeWeapon(Weapon weaponPrefab)
    {
        if(_currentWeapon != null)
        {
            Destroy(_currentWeapon);
        }

        _currentWeapon = Instantiate(weaponPrefab, _weaponPosition);
        _skinRotator.AddSpriteWeapon(_currentWeapon.GetComponent<SpriteRenderer>());
    }

    public void Shoot()
    {
        if(_currentWeapon != null)
        {
            if(_currentInventory.TryGet<Bullet>(out Bullet bullet, true))
            {
                _currentWeapon.Shoot(_skinRotator.IsRightDirection, bullet);
            }
        }
    }
}

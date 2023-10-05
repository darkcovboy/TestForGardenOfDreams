using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Player/Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private Bullet _bulletPrefab;

    public Bullet BulletPrefab => _bulletPrefab;
}

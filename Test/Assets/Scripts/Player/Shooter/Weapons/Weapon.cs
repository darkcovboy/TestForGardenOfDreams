using UnityEngine;

public abstract class Weapon : MonoBehaviour, IItem
{

    [SerializeField] protected WeaponData WeaponData;
    [SerializeField] protected Transform ShootPosition;

    public abstract void Shoot(bool isRightDirection, Bullet bulletPrefab);
}

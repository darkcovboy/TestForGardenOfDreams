using UnityEngine;

public class WeaponPistol : Weapon
{
    public override void Shoot(bool isRightDirection, Bullet bulletPrefab)
    {
        Vector2 direction = isRightDirection ? Vector2.left : Vector2.right;
        var newBullet = Instantiate<Bullet>(bulletPrefab, ShootPosition.position, Quaternion.identity, null);
        newBullet.Initialize(direction);
    }
}

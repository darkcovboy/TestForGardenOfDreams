using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Player/Bullet")]
public class BulletData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;

    public int Damage => _damage;
    public int Speed => _speed;
}

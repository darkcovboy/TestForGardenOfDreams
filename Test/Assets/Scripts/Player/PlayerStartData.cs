using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/StartData")]
public class PlayerStartData : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _startHealth;
    [SerializeField] private Weapon WeaponPrefab;

    public int MaxHealth => _maxHealth;
    public int StartHealth => _startHealth;
    public Weapon Weapon => WeaponPrefab;

    private void OnValidate()
    {
        if(_maxHealth < _startHealth)
        {
            _maxHealth = _startHealth;
            _maxHealth++;
        }
    }
}

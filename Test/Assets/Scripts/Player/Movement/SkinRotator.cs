using UnityEngine;

public class SkinRotator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenders;
    [SerializeField] private MovementHandler _movementHandler;

    public bool IsRightDirection => _weapon.flipX;

    private SpriteRenderer _weapon;

    private void OnEnable()
    {
        _movementHandler.OnRightMove += FlipSprite;
    }

    private void OnDisable()
    {
        _movementHandler.OnRightMove -= FlipSprite;
    }

    public void AddSpriteWeapon(SpriteRenderer weaponSprite)
    {
        _weapon = weaponSprite;
    }

    private void FlipSprite(bool isRight)
    {
        foreach (var sprite in _spriteRenders)
        {
            sprite.flipX = isRight;
        }

        if(_weapon != null)
            _weapon.flipX = isRight;
    }
}

using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class MovementHandler : MonoBehaviour, IMovable
{
    //Можем добавить RequireComponent и получать через GetComponent, но это операция в разы тяжелее, чем если мы положим в Inspector'е

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;

    public event UnityAction<bool> OnRightMove;

    private IInput _input;

    [Inject]
    public void Constructor(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        Vector2 direction = _input.GetInputDirection();
        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        Vector2 movement = new Vector2(direction.x * _speed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = movement;

        if (direction.x < 0)
            OnRightMove?.Invoke(true);
        else
            OnRightMove?.Invoke(false);
    }
}

using UnityEngine;
using Zenject;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset;

    private Transform _target;

    [Inject]
    public void Constructor(IFollowed followed)
    {
        _target = followed.Body;
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            // ≈сли цель не установлена или не существует, просто выходим
            return;
        }

        CalculatePosition();
    }

    private void CalculatePosition()
    {
        // ¬ычисл€ем позицию, к которой камера должна стремитьс€
        Vector3 desiredPosition = _target.position + _offset;

        // »нтерполируем текущую позицию камеры к желаемой позиции с использованием скорости
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        // ”станавливаем позицию камеры
        transform.position = smoothedPosition;
    }
}

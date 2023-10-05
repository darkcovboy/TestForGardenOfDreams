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
            // ���� ���� �� ����������� ��� �� ����������, ������ �������
            return;
        }

        CalculatePosition();
    }

    private void CalculatePosition()
    {
        // ��������� �������, � ������� ������ ������ ����������
        Vector3 desiredPosition = _target.position + _offset;

        // ������������� ������� ������� ������ � �������� ������� � �������������� ��������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        // ������������� ������� ������
        transform.position = smoothedPosition;
    }
}

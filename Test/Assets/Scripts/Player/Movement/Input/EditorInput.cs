using UnityEngine;

public class EditorInput : IInput
{
    //����� ���������� ���������� ��� ��� �����, ��� � ��� �������, �� � ������ ������������(�������) ����� ����� 
    //�������� ���� ���������� ��� ���������� � ����������, ��� ���� ��������� �� �������
    public Vector2 GetInputDirection()
    {
        float horizontalInput = SimpleInput.GetAxis(UsefulConstants.HorizontalAxis);
        Vector2 moveDirection = new Vector2(horizontalInput, 0f).normalized;
        return moveDirection;
    }
}

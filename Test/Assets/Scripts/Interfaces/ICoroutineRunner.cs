using System.Collections;
using UnityEngine;

public interface ICoroutineRunner
{
    //��� ��� Unity �� ����� ��������� �������� �� �� ���������, �� ��� ��� ��� ����� ������������, ����� ������ �������� �������� �� ������ ������.
    Coroutine StartCoroutine(IEnumerator coroutine);
}

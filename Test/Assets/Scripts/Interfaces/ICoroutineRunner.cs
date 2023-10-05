using System.Collections;
using UnityEngine;

public interface ICoroutineRunner
{
    //“ак как Unity не хочет запускать корутины не на монобехах, то вот так вот можем извертнутьс€, чтобы запуск корутины повесить на другой объект.
    Coroutine StartCoroutine(IEnumerator coroutine);
}

using UnityEngine;

public interface IObjectFactory<T>
{
    public T Create(Vector2 position);
}

using System;

public interface IRemovable<T>
{
    public event Action<T> OnDiyng; 
}

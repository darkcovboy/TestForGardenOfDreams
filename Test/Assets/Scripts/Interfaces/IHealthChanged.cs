using UnityEngine.Events;

public interface IHealthChanged
{
    public event UnityAction<int, int> OnHealthChanged;
}

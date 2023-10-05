using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private IHealthChanged _healthChanged;

    public void Constructor(IHealthChanged healthChanged)
    {
        _healthChanged = healthChanged;
        _healthChanged.OnHealthChanged += OnValueChanged;
        _slider.interactable = false;
    }

    private void OnDisable()
    {
        _healthChanged.OnHealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value, int max)
    {
        _slider.maxValue = max;
        _slider.value = value;
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : BaseHealthView
{
    [SerializeField] private Slider _slider;

    protected override void Awake()
    {
        base.Awake();
        _slider.minValue = MinHealth;
        _slider.maxValue = MaxHealth;
        _slider.value = MaxHealth;
    }

    protected override void UpdateValue(int value)
    {
        _slider.value = value;
    }
}

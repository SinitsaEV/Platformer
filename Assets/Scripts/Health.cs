using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxValue = 100;
    private int _minValue = 0;
    private int _currentValue;

    public Action<int> ValueChanged;

    public int MaxValue => _maxValue;
    public int MinValue => _minValue;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage > _minValue)
        {
            _currentValue -= damage;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
            ValueChanged?.Invoke(_currentValue);
        }
    }

    public void Heal(int health)
    {
        if (health > _minValue)
        {
            _currentValue += health;
            _currentValue = Mathf.Clamp(_currentValue, _minValue, _maxValue);
            ValueChanged?.Invoke(_currentValue);
        }
    }
}

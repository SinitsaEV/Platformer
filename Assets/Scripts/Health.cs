using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;

    public Action<int> ValueChanged;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            ValueChanged?.Invoke(_currentHealth);
        }
    }

    public void Heal(int health)
    {
        if(health > 0)
        {
            _currentHealth += health;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            ValueChanged?.Invoke(_currentHealth);
        }
    }
}

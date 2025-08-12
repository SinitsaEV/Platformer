using System;
using System.Collections;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected float Delay;
    protected bool IsRecharging = false;
    protected bool IsActive = false;
    protected Transform Transform;

    protected float _tick = 0.5f;
    protected float _maxEnergy = 1;
    protected float _minEnergy = 0;
    protected float _currentEnergy;
    protected WaitForSeconds _tickTime;

    public Action OnStarted; 
    public Action OnEnded;
    public Action<float> EnergyUpdated;

    protected virtual void Awake()
    {
        _tickTime = new WaitForSeconds(_tick);
        Transform = transform;
        _currentEnergy = _maxEnergy;
        EnergyUpdated?.Invoke(_currentEnergy);
    }

    private IEnumerator Cooldown()
    {
        while (_currentEnergy != _maxEnergy)
        {
            yield return _tickTime;

            ChangeEnergy(_tick / Delay);
        }

        IsRecharging = false;
    }

    protected void Recharge()
    {
        if (IsRecharging == false)
        {
            IsRecharging = true;
            StartCoroutine(Cooldown());
        }
    }

    protected void ChangeEnergy(float value)
    {
        _currentEnergy += value;
        _currentEnergy = Mathf.Clamp(_currentEnergy, _minEnergy, _maxEnergy);
        EnergyUpdated?.Invoke(_currentEnergy);
    }

    public abstract void Active();
}

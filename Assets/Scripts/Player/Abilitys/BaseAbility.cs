using System;
using System.Collections;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected float Delay;
    protected bool IsRecharging = false;
    protected bool IsActive = false;
    protected Transform Transform;

    protected float Tick = 0.5f;
    protected float MaxEnergy = 1;
    protected float MinEnergy = 0;
    protected float CurrentEnergy;
    protected WaitForSeconds TickTime;

    public Action OnStarted; 
    public Action OnEnded;
    public Action<float> EnergyUpdated;

    protected virtual void Awake()
    {
        TickTime = new WaitForSeconds(Tick);
        Transform = transform;
        CurrentEnergy = MaxEnergy;
        EnergyUpdated?.Invoke(CurrentEnergy);
    }

    private IEnumerator Cooldown()
    {
        while (CurrentEnergy != MaxEnergy)
        {
            yield return TickTime;

            ChangeEnergy(Tick / Delay);
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
        CurrentEnergy += value;
        CurrentEnergy = Mathf.Clamp(CurrentEnergy, MinEnergy, MaxEnergy);
        EnergyUpdated?.Invoke(CurrentEnergy);
    }

    public abstract void Active();
}

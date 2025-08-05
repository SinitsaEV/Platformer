using System;
using System.Collections;
using UnityEngine;

public abstract class BaseAbility : MonoBehaviour
{
    [SerializeField] protected float Delay;
    protected bool IsRecharging = false;
    protected Transform Transform;
    private WaitForSeconds _rechargeTime;

    public Action OnStarted; 
    public Action OnEnded;

    protected virtual void Awake()
    {
        _rechargeTime = new WaitForSeconds(Delay);
        Transform = transform;
    }

    private IEnumerator Cooldown()
    {
        IsRecharging = true;

        yield return _rechargeTime;

        IsRecharging = false;
    }

    protected void Recharge()
    {
        StartCoroutine(Cooldown());
    }

    public abstract void Active();
}

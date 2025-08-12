using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : BaseAbility
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damage = 15;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _range = 3f;

    private IAttacker _attacker;
    private Health _health;

    public float Range => _range;
    
    protected override void Awake()
    {
        base.Awake();
        _attacker = GetComponentInParent<IAttacker>();
        _health = GetComponentInParent<Health>();
    }

    public override void Active()
    {
        if (IsRecharging == false && IsActive == false)
        {
            IsActive = true;
            OnStarted?.Invoke();
            StartCoroutine(VampirismRoutine());            
        }
    }

    private List<IDamageable> GetTargets()
    {
        List<IDamageable> damageables = new List<IDamageable>();

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(Transform.position, _range, _enemyLayerMask))
        {
            if(collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageables.Add(damageable);
            }
        }

        return damageables;
    }

    private IEnumerator VampirismRoutine()
    {               
        while (_currentEnergy != _minEnergy)
        {
            yield return _tickTime;

            ChangeEnergy(-_tick / _duration);

            List<IDamageable> targets = GetTargets();

            foreach(IDamageable damageable in targets)
            {
                _attacker.Attack(damageable, _damage);
                _health.Heal(_damage);
            }            
        }

        IsActive = false;
        OnEnded?.Invoke();
        Recharge();
    }
}

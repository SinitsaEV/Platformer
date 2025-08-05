using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : BaseAbility
{
    [SerializeField] private LayerMask _layerMask;
    private int _damage = 15;
    private float _duration = 3f;
    private float _range = 2f;
    private float _attackSpeed = 1f;
    private WaitForSeconds _attackDelay;
    private IAttacker _attacker;
    private Health _health;
    float remainingTime;

    protected override void Awake()
    {
        base.Awake();
        _attackDelay = new WaitForSeconds(_attackSpeed);
        _attacker = GetComponentInParent<IAttacker>();
        _health = GetComponentInParent<Health>();
        remainingTime = _duration;
    }

    public override void Active()
    {
        if(IsRecharging == false)
        {
            StartCoroutine(VampirismRoutine());
        }
    }

    private List<IDamageable> GetTargets()
    {
        List<IDamageable> damageables = new List<IDamageable>();

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(Transform.position, _range, _layerMask))
        {
            if(collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {
                damageables.Add(damageable);
            }
        }

        return damageables;
    }

    private void FixedUpdate()
    {
        if (remainingTime <= 0)
            remainingTime = _duration;

        remainingTime -= Time.deltaTime;
    }

    private IEnumerator VampirismRoutine()
    {               
        OnStarted?.Invoke();

        while (remainingTime > 0)
        {
            List<IDamageable> targets = GetTargets();

            foreach(IDamageable damageable in targets)
            {
                _attacker.Attack(damageable, _damage);
                _health.Heal(_damage);
            }

            yield return _attackDelay;
        }

        OnEnded?.Invoke();
        Recharge();
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(NearestEnemyDetector))]
public class Vampirism : BaseAbility
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private int _damage = 15;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _range = 3f;

    private IAttacker _attacker;
    private NearestEnemyDetector _nearestEnemyDetector;
    private Health _health;

    public float Range => _range;
    
    protected override void Awake()
    {
        base.Awake();
        _attacker = GetComponentInParent<IAttacker>();
        _health = GetComponentInParent<Health>();
        _nearestEnemyDetector = GetComponent<NearestEnemyDetector>();
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

    private IEnumerator VampirismRoutine()
    {
        while (CurrentEnergy != MinEnergy)
        {
            yield return TickTime;

            ChangeEnergy(-Tick / _duration);

            IDamageable target = _nearestEnemyDetector.GetClosestTargetInRange(Range, _enemyLayerMask);

            if (target != null)
            {
                _attacker.Attack(target, _damage);
                _health.Heal(_damage);
            }
        }

        IsActive = false;
        OnEnded?.Invoke();
        Recharge();
    }
}

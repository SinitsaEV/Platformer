public class AttackState : EnemyState
{
    private readonly IAttackDetector _attackDetector;
    private readonly ITargetDetector _playerDetector;
    private readonly IAttacker _attacker;
    private readonly int _damage;

    public AttackState(EnemyDependencies enemyDependencies, IStateChanger stateChager) : base(stateChager)
    {
        _attackDetector = enemyDependencies.AttackDetector;
        _playerDetector = enemyDependencies.PlayerDetector;
        _attacker = enemyDependencies.Attacker;
        _damage = enemyDependencies.Damage;
    }

    public override void Update()
    {
        if (_playerDetector.IsTargetDetected == false)
            _changer.ChangeState<PatrolState>();

        if(_attackDetector.CanAttack == false)
            _changer.ChangeState<ChaseState>();

        _attacker.Attack(_playerDetector.Damageable, _damage);
    }
}

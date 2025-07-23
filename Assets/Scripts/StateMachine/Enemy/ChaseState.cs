using UnityEngine;
using static UnityEngine.CullingGroup;

public class ChaseState : EnemyState
{
    private readonly IMovable _movable;
    private readonly ITargetDetector _playerDetector;
    private readonly IAttackDetector _attackDetector;
    private readonly Chase _chase;


    public ChaseState(EnemyDependencies enemyDependencies, IStateChanger stateChager) : base(stateChager)
    {
        _playerDetector = enemyDependencies.PlayerDetector;
        _movable = enemyDependencies.Movable;
        _attackDetector = enemyDependencies.AttackDetector;
        _chase = enemyDependencies.Chase;
    }

    public override void Update()
    {
        if(_playerDetector.IsTargetDetected == false)
        {
            _changer.ChangeState<PatrolState>();
        }

        if (_attackDetector.CanAttack)
        {
            _changer.ChangeState<AttackState>();
        }

        _chase.SetTarget(_playerDetector.LastPosition);
        _movable.Move(_chase.GetChaseDirection());
    }
}

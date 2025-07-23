public class PatrolState : EnemyState
{
    private IMovable _movable;
    private ITargetDetector _playerDetector;
    private Patrol _patrol;

    public PatrolState(EnemyDependencies enemyDependencies,IStateChanger stateChager) : base(stateChager)
    {
        _playerDetector = enemyDependencies.PlayerDetector;
        _movable = enemyDependencies.Movable;
        _patrol = enemyDependencies.Patrol;
    }

    public override void Update()
    {
        if (_playerDetector.IsTargetDetected)
        {   
            _changer.ChangeState<ChaseState>();            
        }

        _movable.Move(_patrol.GetPatrolDirection());
    }
}

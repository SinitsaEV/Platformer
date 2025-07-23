public class EnemyStateMachineFactory 
{
    public IStateMachine CreateEnemyStateMachine(EnemyDependencies dependencies)
    {
        StateMachine stateMachine = new StateMachine();

        PatrolState patrolState = new PatrolState(dependencies,stateMachine);
        ChaseState chaseState = new ChaseState(dependencies,stateMachine);
        AttackState attackState = new AttackState(dependencies,stateMachine);

        stateMachine.AddState<PatrolState>(patrolState);
        stateMachine.AddState<ChaseState>(chaseState);
        stateMachine.AddState<AttackState>(attackState);

        stateMachine.SetFirstState<PatrolState>();

        return stateMachine;
    }
}

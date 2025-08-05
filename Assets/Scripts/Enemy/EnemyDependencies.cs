public class EnemyDependencies
{
    public readonly IAttacker Attacker;
    public readonly IAttackDetector AttackDetector;
    public readonly ITargetDetector PlayerDetector;
    public readonly Patrol Patrol;
    public readonly Chase Chase;
    public readonly IMovable Movable;
    public readonly int Damage;

    public EnemyDependencies(IAttacker attacker, IAttackDetector attackDetector, ITargetDetector playerDetector, Patrol patrol, Chase chase, IMovable movable, int damage)
    {
        Attacker = attacker;
        AttackDetector = attackDetector;
        PlayerDetector = playerDetector;
        Patrol = patrol;
        Chase = chase;
        Movable = movable;
        Damage = damage;
    }
}

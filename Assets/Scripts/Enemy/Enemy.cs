using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rotator _rotator;
    private IStateMachine _machine;
    private Rigidbody2D _rigidbody;
    private EnemyDependencies _dependencies;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _dependencies = new EnemyDependencies(
            GetComponent<IAttacker>(),
            GetComponent<IAttackDetector>(),
            GetComponent<ITargetDetector>(),
            GetComponent<Patrol>(),
            GetComponent<Chase>(),
            GetComponent<IMovable>());

        EnemyStateMachineFactory stateMachineFactory = new EnemyStateMachineFactory();
        _machine = stateMachineFactory.CreateEnemyStateMachine(_dependencies);
    }

    private void Update()
    {
        _machine.Update();
        _rotator.Rotate(_rigidbody.velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, 5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}

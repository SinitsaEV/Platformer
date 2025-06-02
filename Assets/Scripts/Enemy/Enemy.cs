using UnityEngine;

[RequireComponent (typeof(Rotator))]
[RequireComponent (typeof(Mover))]
[RequireComponent (typeof(Patrol))]
public class Enemy : MonoBehaviour
{
    private Rotator _rotator;
    private Mover _mover;
    private Patrol _patrol;

    private void Awake()
    {
        _rotator = GetComponent<Rotator>();
        _mover = GetComponent<Mover>();
        _patrol = GetComponent<Patrol>();
    }

    private void Update()
    {
        _mover.Move(_patrol.GetPatrolDirection());
        _rotator.Rotate(_patrol.GetPatrolDirection());
    }
}

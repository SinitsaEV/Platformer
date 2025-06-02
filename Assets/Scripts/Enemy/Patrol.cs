using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float _distanсe = 5f;
    private Transform _transform;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private Vector2 _direction;

    private void Awake()
    {
        _transform = transform;
        _endPosition = new Vector2(_transform.position.x + _distanсe, _transform.position.y);
        _startPosition = _transform.position;
        ChangeDirection();
    }

    public Vector2 GetPatrolDirection()
    {
        if ((_startPosition - (Vector2)_transform.position).sqrMagnitude >= _distanсe * _distanсe)
        {
            (_startPosition, _endPosition) = (_endPosition, _startPosition);
            ChangeDirection();
        }

        return _direction;
    }

    private void ChangeDirection()
    {
        _direction = (_endPosition - (Vector2)_transform.position).normalized;
    }
}

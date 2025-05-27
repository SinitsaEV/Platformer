using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _distanse = 5f;
    [SerializeField] private float _moveSpeed = 3f;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private Vector2 _direction;

    private float _flipThreshold = 0.1f;
    private bool _isFacingRight = false;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        _endPosition = new Vector2(_transform.position.x + _distanse, _transform.position.y);
        _startPosition = _transform.position;
        ChangeDirection();
    }

    private void Update()
    {
        Patrol();
        Rotate();
    }

    private void Patrol()
    {
        _rigidbody.velocity = new Vector2(_direction.x * _moveSpeed, _rigidbody.velocity.y);

        if ((_startPosition - (Vector2)_transform.position).sqrMagnitude >= _distanse * _distanse)
        {
            (_startPosition,_endPosition) = (_endPosition,_startPosition);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        _direction = (_endPosition - (Vector2)_transform.position).normalized;
    }

    private void Rotate()
    {
        if (Mathf.Abs(_direction.x) > _flipThreshold)
        {
            bool isMoveRight = _direction.x > 0;

            if (isMoveRight != _isFacingRight)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 newScale = _transform.localScale;
                newScale.x = -newScale.x;
                _transform.localScale = newScale;
            }
        }
    }
}

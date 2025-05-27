using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private MovementController _movement;

    private string _speedParam = "Speed";
    private string _jumpParam = "IsJumping";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _movement = GetComponent<MovementController>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(_speedParam, speed);
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y > 0.1f && !_movement.IsGrounded)
        {
            _animator.SetTrigger(_jumpParam);
        }
    }
}
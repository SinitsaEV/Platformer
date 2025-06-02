using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;

    private string _speedParam = "Speed";
    private string _jumpParam = "IsJumping";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(_speedParam, speed);
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.y > 0.1f && _groundDetector.IsGrounded() == false)
        {
            _animator.SetTrigger(_jumpParam);
        }
    }
}
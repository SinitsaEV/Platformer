using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAnimationController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private Animator _animator;
    private string _speedParamName = "Speed";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(_rigidbody.velocity.x);
        _animator.SetFloat(_speedParamName, speed);
    }
}
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rotator _rotator;
    private Mover _playerMover;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Attacker _attacker;
    private TargetDetector _targetDetector;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerMover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
        _attacker = GetComponent<Attacker>();
        _targetDetector = GetComponent<TargetDetector>();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.Direction);
        _rotator.Rotate(_inputReader.Direction);

        if (_targetDetector.IsTargetDetected && _attacker.CanAttack)
            _attacker.Attack(_targetDetector.Damageable);

        if (_inputReader.IsJump && _groundDetector.IsGrounded())
            _playerMover.Jump();
    }
}

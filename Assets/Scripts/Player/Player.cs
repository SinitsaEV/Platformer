using UnityEngine;

public class Player : MonoBehaviour
{
    private Rotator _rotator;
    private Mover _playerMover;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Attacker _attacker;
    private TargetDetector _targetDetector;
    private Vampirism _vampirism;
    private int _damage = 10;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerMover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
        _attacker = GetComponent<Attacker>();
        _targetDetector = GetComponent<TargetDetector>();
        _vampirism = GetComponentInChildren<Vampirism>();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.Direction);
        _rotator.Rotate(_inputReader.Direction);

        if (_targetDetector.IsTargetDetected && _attacker.CanAttack)
            _attacker.Attack(_targetDetector.Damageable, _damage);

        if (_inputReader.IsJump && _groundDetector.IsGrounded())
            _playerMover.Jump();

        if (_inputReader.IsVampire)
            _vampirism.Active();
    }
}

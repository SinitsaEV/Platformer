using UnityEngine;

public class Player : MonoBehaviour
{
    private Rotator _rotator;
    private Mover _playerMover;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _playerMover = GetComponent<Mover>();
        _rotator = GetComponent<Rotator>();
    }

    private void FixedUpdate()
    {
        _playerMover.Move(_inputReader.Direction);
        _rotator.Rotate(_inputReader.Direction);

        if (_inputReader.IsJump && _groundDetector.IsGrounded())
            _playerMover.Jump();
    }
}

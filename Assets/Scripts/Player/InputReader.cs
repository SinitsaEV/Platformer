using UnityEngine;

public class InputReader : MonoBehaviour
{
    private PlayerInput _playerInput;

    public bool IsJump { get; private set; }
    public bool IsVampire { get; private set; }
    public Vector2 Direction { get; private set; }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Jump.performed += ctx => IsJump = true;
        _playerInput.Player.Jump.canceled += ctx => IsJump = false;
        _playerInput.Player.Vampire.performed += ctx => IsVampire = true;
        _playerInput.Player.Vampire.canceled += ctx => IsVampire = false;
    }

    private void Update()
    {
        Direction = _playerInput.Player.Move.ReadValue<Vector2>();       
    }

    private void OnDisable()
    {
        _playerInput.Player.Jump.performed -= ctx => IsJump = true;
        _playerInput.Player.Jump.canceled -= ctx => IsJump = false;
        _playerInput.Player.Vampire.performed -= ctx => IsVampire = true;
        _playerInput.Player.Vampire.canceled -= ctx => IsVampire = false;
        _playerInput.Disable();
    }
}

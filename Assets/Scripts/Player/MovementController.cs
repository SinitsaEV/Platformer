using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForse = 10f;
    [SerializeField] private LayerMask _groundLayerMask;
    private Vector2 _direction;

    private float _groundCheckDistance = 0.5f;
    private bool _isGrounded;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private Transform _transform;
    private Rotator _rotator;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
        _rotator = GetComponent<Rotator>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Jump.performed += OnJump;
    }

    private void Update()
    {
        IsGrounded();
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();
        Move();
        _rotator.Rotate(_direction);
    }

    private void OnDisable()
    {
        _playerInput.Player.Jump.performed -= OnJump;
        _playerInput.Disable();
    }

    public bool IsGrounded()
    {
        _isGrounded = false;

        RaycastHit2D hit = Physics2D.Raycast(_transform.position, Vector2.down, _groundCheckDistance, _groundLayerMask);

        if(hit.collider != null)
        {
            _isGrounded = true;
        }     
        
        return _isGrounded;
    }   

    private void Move()
    {        
        _rigidbody.velocity = new Vector2(_direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
            _rigidbody.AddForce(_transform.up * _jumpForse, ForceMode2D.Impulse);
    }
}

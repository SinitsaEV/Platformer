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

    private float _flipThreshold = 0.1f;
    private bool _isFacingRight = false;

    private Rigidbody2D _rigidbody;
    private PlayerInput _playerInput;
    private Transform _transform;

    public bool IsGrounded =>_isGrounded;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;

        _playerInput.Player.Jump.performed += OnJump;
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        CheckGround();
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();
        Move();
        Rotate();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
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

    private void CheckGround()
    {
        _isGrounded = false;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance, _groundLayerMask);

        if(hit.collider != null)
        {
            _isGrounded = true;
        }        
    }   

    private void Move()
    {        
        _rigidbody.velocity = new Vector2(_direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
            _rigidbody.AddForce(transform.up * _jumpForse, ForceMode2D.Impulse);
    }
}

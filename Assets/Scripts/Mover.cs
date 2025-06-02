using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpForse = 10f;
       
    private Rigidbody2D _rigidbody;  
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = transform;
    }

    public void Move(Vector2 direction)
    {        
        _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.AddForce(_transform.up * _jumpForse, ForceMode2D.Impulse);
    }
}

using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayerMask;

    private float _groundCheckDistance = 0.5f;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public bool IsGrounded()
    {        
        return Physics2D.Raycast(_transform.position, Vector2.down, _groundCheckDistance, _groundLayerMask);
    }
}

using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _flipThreshold = 0.1f;
    private float _flipAngle = 180f;

    private Transform _transform;

    private Quaternion _leftRotation;
    private Quaternion _rightRotation;
    private bool _isFacingRight = false;

    private void Awake()
    {
        _transform = transform;
        _leftRotation = _transform.rotation;
        _rightRotation = Quaternion.Euler(_rightRotation.eulerAngles.x,
                                       _rightRotation.eulerAngles.y + _flipAngle,
                                       _rightRotation.eulerAngles.z);
    }

    public void Rotate(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > _flipThreshold)
        {
            bool shouldFaceRight = direction.x > 0;

            if (shouldFaceRight != _isFacingRight)
            {
                _isFacingRight = shouldFaceRight;
                _transform.rotation = _isFacingRight ? _rightRotation : _leftRotation;
            }
        }
    }
}
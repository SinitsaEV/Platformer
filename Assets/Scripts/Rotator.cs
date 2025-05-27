using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float _flipThreshold = 0.1f;
    private bool _isFacingRight = false;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public void Rotate(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > _flipThreshold)
        {
            bool isMoveRight = direction.x > 0;

            if (isMoveRight != _isFacingRight)
            {
                _isFacingRight = !_isFacingRight;
                Vector3 newScale = _transform.localScale;
                newScale.x = -newScale.x;
                _transform.localScale = newScale;
            }
        }
    }
}

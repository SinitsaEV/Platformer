using UnityEngine;

public abstract class BaseDetector : MonoBehaviour
{
    protected Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    protected Collider2D[] GetCollidersInRange(float range, LayerMask layerMask)
    {
        return Physics2D.OverlapCircleAll(_transform.position, range, layerMask);
    }
}

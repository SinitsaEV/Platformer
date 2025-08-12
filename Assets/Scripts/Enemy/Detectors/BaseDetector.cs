using UnityEngine;

public abstract class BaseDetector : MonoBehaviour
{
    protected Transform Transform;

    private void Awake()
    {
        Transform = GetComponent<Transform>();
    }

    protected Collider2D[] GetCollidersInRange(float range, LayerMask layerMask)
    {
        return Physics2D.OverlapCircleAll(Transform.position, range, layerMask);
    }
}

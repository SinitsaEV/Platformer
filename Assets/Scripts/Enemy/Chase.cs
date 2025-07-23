using UnityEngine;

public class Chase : MonoBehaviour
{
    private Transform _target;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public Vector2 GetChaseDirection()
    {
        Vector2 direction = Vector2.zero;

        if (_target != null)
            direction = (_target.position - _transform.position).normalized;
            
        return direction;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}

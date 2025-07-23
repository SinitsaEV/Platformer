using UnityEngine;

public class TargetDetector : BaseDetector, ITargetDetector
{
    [SerializeField] private float _range = 5f;
    [SerializeField] private LayerMask _targetLayer;

    public bool IsTargetDetected => TryGetTarget();

    public Transform LastPosition { get; private set; }
    public IDamageable Damageable { get; private set; }

    private bool TryGetTarget()
    {
        foreach (Collider2D collider in GetCollidersInRange(_range, _targetLayer))
        {
            if(collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {                
                LastPosition = collider.transform;
                Damageable = collider.GetComponent<IDamageable>();
                return true;
            }
        }

        return false;
    }
}

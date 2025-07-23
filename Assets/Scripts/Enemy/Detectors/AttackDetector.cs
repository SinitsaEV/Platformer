using UnityEngine;

public class AttackDetector :BaseDetector, IAttackDetector
{
    [SerializeField] private float _range = 1f;
    [SerializeField] private LayerMask _targetLayer;

    public bool CanAttack => TryGetTarget();

    private bool TryGetTarget()
    {
        foreach (Collider2D collider in GetCollidersInRange(_range, _targetLayer))
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
            {                
                return true;
            }
        }

        return false;
    }
}

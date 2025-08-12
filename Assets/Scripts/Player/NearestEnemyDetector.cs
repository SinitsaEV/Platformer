using UnityEngine;

public class NearestEnemyDetector : BaseDetector
{
    public IDamageable GetClosestTargetInRange(float range, LayerMask targetLayerMask)
    {
        IDamageable closestDamageable = null;
        float distanceToClosestEnemySquared = Mathf.Infinity;

        foreach(Collider2D collider in GetCollidersInRange(range, targetLayerMask))
        {
            if (collider.TryGetComponent<IDamageable>(out IDamageable damageable) == false)
            {
                continue;
            }

            float distanceSquared = (collider.transform.position - Transform.position).sqrMagnitude;

            if (distanceSquared < distanceToClosestEnemySquared)
            {
                closestDamageable = damageable;
                distanceToClosestEnemySquared = distanceSquared;
            }
        }

        return closestDamageable;
    }
}

using UnityEngine;

public interface ITargetDetector 
{
    bool IsTargetDetected { get; }

    Transform LastPosition { get; }
    IDamageable Damageable { get; }
}

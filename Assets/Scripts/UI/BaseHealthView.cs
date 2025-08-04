using UnityEngine;

public abstract class BaseHealthView : MonoBehaviour
{
    protected Health Health;
    protected int MaxHealth;
    protected int MinHealth;

    private void OnEnable()
    {
        Health.ValueChanged += UpdateValue;
    }

    protected virtual void Awake()
    {
        Health = GetComponentInParent<Health>();
        MaxHealth = Health.MaxValue;
        MinHealth = Health.MinValue;
        UpdateValue(MaxHealth);
    }

    private void OnDisable()
    {
        Health.ValueChanged -= UpdateValue;
    }

    protected abstract void UpdateValue(int value);    
}

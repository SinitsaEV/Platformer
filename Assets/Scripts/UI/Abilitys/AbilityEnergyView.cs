using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BaseAbility))]
public class AbilityEnergyView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private BaseAbility _baseAbility;

    private void Awake()
    {
        _baseAbility = GetComponent<BaseAbility>();
    }

    private void OnEnable()
    {
        _baseAbility.EnergyUpdated += OnEnergyUpdated;
    }

    private void OnDisable()
    {
        _baseAbility.EnergyUpdated -= OnEnergyUpdated;
    }

    private void OnEnergyUpdated(float value)
    {
        _slider.value = value;
    }
}

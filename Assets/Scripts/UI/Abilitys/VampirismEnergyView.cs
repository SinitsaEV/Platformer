using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Vampirism))]
public class VampirismEnergyView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private Vampirism _vampirism;

    private void Awake()
    {
        _vampirism = GetComponent<Vampirism>();
    }

    private void OnEnable()
    {
        _vampirism.EnergyUpdated += OnEnergyUpdated;
    }

    private void OnDisable()
    {
        _vampirism.EnergyUpdated -= OnEnergyUpdated;
    }

    private void OnEnergyUpdated(float value)
    {
        _slider.value = value;
    }
}

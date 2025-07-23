using TMPro;
using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Health _health;

    private string _formate = "HP: ";

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = _formate + value.ToString();
    }
}

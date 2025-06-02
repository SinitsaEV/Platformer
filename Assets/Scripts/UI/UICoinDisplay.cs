using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Wallet _wallet; 

    private string _formate = "Coins: ";

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnEnable()
    {
        _wallet.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _text.text = _formate + value.ToString();
    }
}

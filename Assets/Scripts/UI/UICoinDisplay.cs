using TMPro;
using UnityEngine;

public class UICoinDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private string _formate = "Coins: ";

    public void UpdateText(int value)
    {
        _text.text = _formate + value.ToString();
    }
}

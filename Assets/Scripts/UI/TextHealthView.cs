using TMPro;
using UnityEngine;

public class TextHealthView : BaseHealthView
{
    [SerializeField] private TMP_Text _text;

    private string _formate = "HP: ";
    private string _delimiter = "|";
    
    protected override void UpdateValue(int value)
    {
        _text.text = _formate + value.ToString() + _delimiter + Health.MaxValue.ToString();
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBarView : BaseHealthView
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _smoothSpeed;

    private float _currentValue;
    private float _targetValue;
    private Coroutine _currentCoroutine;

    protected override void Awake()
    {
        base.Awake();
        _currentValue = MaxHealth;
        _slider.minValue = MinHealth;
        _slider.maxValue = MaxHealth;
        _slider.value = MaxHealth;        
    }

    protected override void UpdateValue(int value)
    {
        _targetValue = value;

        if (_currentCoroutine != null)
            StopCoroutine(FlashDamage());

        StartCoroutine(FlashDamage());
    }   
    
    private IEnumerator FlashDamage()
    {
        while (Mathf.Approximately(_currentValue, _targetValue) == false)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, _targetValue, _smoothSpeed * Time.deltaTime);            
            _slider.value = _currentValue;
            yield return null;
        }
    }
}

using UnityEngine;

public class CoinSystem : MonoBehaviour
{
    private Collector _collector;
    private UICoinDisplay _coinDisplay;

    private int _money = 0;

    private void Awake()
    {
        _collector = GetComponent<Collector>();
        _coinDisplay = GetComponent<UICoinDisplay>();
    }

    private void OnEnable()
    {
        _collector.CoinCollected += AddCoin;
    }

    private void OnDisable()
    {
        _collector.CoinCollected -= AddCoin;
    }

    private void AddCoin(int value)
    {
        if (value > 0)
        {
            _money += value;
            _coinDisplay.UpdateText(_money);
        }
    }
}

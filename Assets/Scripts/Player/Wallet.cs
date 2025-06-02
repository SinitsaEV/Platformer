using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{    
    private int _value = 0;

    public Action<int> ValueChanged;

    public void AddCoin(Coin coin)
    {
        if (coin.Value > 0)
        {
            _value += coin.Value;
            ValueChanged?.Invoke(_value);
        }
    }
}

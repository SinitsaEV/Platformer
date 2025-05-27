using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private int _value = 10;

    public Action<Coin> Collected;

    public void Collect(Collector collector)
    {
        collector.AddCoin(_value);
        Collected?.Invoke(this);
    }
}

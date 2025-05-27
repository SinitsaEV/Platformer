using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    public Action<int> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
            return;

        if(collision.TryGetComponent<ICollectible>(out ICollectible collectible))
        {
            collectible.Collect(this);
        }
    }

    public void AddCoin(int points)
    {
        CoinCollected?.Invoke(points);
    }
}
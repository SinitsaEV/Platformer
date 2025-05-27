using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : BaseSpawner
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private bool _isWork = true;
    [SerializeField] private float _delay = 2f;

    private Transform _transform;
    private Queue<Coin> _coinPool = new Queue<Coin>();

    private WaitForSeconds _seconds;
    private Coroutine _spawningCoroutine;

    private void Awake()
    {
        _transform = transform;
        _seconds = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (_isWork && _spawningCoroutine == null)
        {
            _spawningCoroutine = StartCoroutine(SpawningCoroutine());
        }
    }

    private void ReturnCoin(Coin coin)
    {
        if (coin != null && !_coinPool.Contains(coin))
        {
            coin.gameObject.SetActive(false);
            _coinPool.Enqueue(coin);
        }
    }

    protected override void Spawn()
    {
        if (_coinPool.Count == 0)
        {
            CreateCoin();
        }

        GetCoin();
    }

    private void GetCoin()
    {
        Coin coin = _coinPool.Dequeue();
        coin.transform.position = GetRandomPosition(_transform);
        coin.gameObject.SetActive(true);
    }

    private void CreateCoin()
    {
        Coin newCoin = Instantiate(_prefab, _transform);
        newCoin.gameObject.SetActive(false);
        newCoin.Collected += ReturnCoin;
        _coinPool.Enqueue(newCoin);
    }

    private IEnumerator SpawningCoroutine()
    {
        while (_isWork)
        {
            Spawn();
            yield return _seconds;
        }

        _spawningCoroutine = null;
    }
}

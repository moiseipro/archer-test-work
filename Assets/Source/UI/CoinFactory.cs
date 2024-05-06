using System;
using Source.UI.Mono;
using UnityEngine;

namespace Source.UI
{
    public class CoinFactory
    {
        private readonly CoinPool _coinPool;

        public Action<CoinView> OnCreatedCoin;
        
        private CoinFactory(CoinPool coinPool)
        {
            _coinPool = coinPool;
        }

        public void Create(Vector2 position)
        {
            CoinView coinView = _coinPool.Pool.Get();
            coinView.SetPosition(position);
            OnCreatedCoin?.Invoke(coinView);
        }

        public void ReturnToPool(CoinView coinView)
        {
            _coinPool.Pool.Release(coinView);
        }
    }
}
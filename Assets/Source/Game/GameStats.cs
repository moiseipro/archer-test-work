using System;
using UnityEngine;

namespace Source.Game
{
    public class GameStats
    {
        private int _money = 0;
        public int Money => _money;

        public Action<int> OnCollectCoin;
        
        public void CollectCoin()
        {
            _money++;
            OnCollectCoin?.Invoke(_money);
        }
    }
}
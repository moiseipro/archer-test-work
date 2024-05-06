using UnityEngine;
using UnityEngine.Pool;

namespace Source.UI.Mono
{
    public class CoinPool : MonoBehaviour
    {
        public CoinView coinView;
        
        public enum PoolType
        {
            Stack,
            LinkedList
        }

        public PoolType poolType;
        
        public bool collectionChecks = true;
        public int maxPoolSize = 10;

        IObjectPool<CoinView> m_Pool;

        public IObjectPool<CoinView> Pool
        {
            get
            {
                if (m_Pool == null)
                {
                    if (poolType == PoolType.Stack)
                        m_Pool = new ObjectPool<CoinView>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        m_Pool = new LinkedPool<CoinView>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return m_Pool;
            }
        }

        CoinView CreatePooledItem()
        {
            var coin = Instantiate(coinView, transform);
            return coin;
        }
        
        void OnReturnedToPool(CoinView coin)
        {
            coin.gameObject.SetActive(false);
        }
        
        void OnTakeFromPool(CoinView coin)
        {
            coin.gameObject.SetActive(true);
        }
        
        void OnDestroyPoolObject(CoinView coin)
        {
            Destroy(coin.gameObject);
        }
    }
}
using UnityEngine;
using UnityEngine.Pool;

namespace Source.Weapon.Mono
{
    public class BulletPool : MonoBehaviour
    {
        public BulletView bulletView;
        
        public enum PoolType
        {
            Stack,
            LinkedList
        }

        public PoolType poolType;
        
        public bool collectionChecks = true;
        public int maxPoolSize = 10;

        IObjectPool<BulletView> m_Pool;

        public IObjectPool<BulletView> Pool
        {
            get
            {
                if (m_Pool == null)
                {
                    if (poolType == PoolType.Stack)
                        m_Pool = new ObjectPool<BulletView>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);
                    else
                        m_Pool = new LinkedPool<BulletView>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, maxPoolSize);
                }
                return m_Pool;
            }
        }

        BulletView CreatePooledItem()
        {
            var bullet = Instantiate(bulletView, transform);
            return bullet;
        }
        
        void OnReturnedToPool(BulletView bullet)
        {
            bullet.gameObject.SetActive(false);
        }
        
        void OnTakeFromPool(BulletView bullet)
        {
            bullet.gameObject.SetActive(true);
        }
        
        void OnDestroyPoolObject(BulletView bullet)
        {
            Destroy(bullet.gameObject);
        }
    }
}
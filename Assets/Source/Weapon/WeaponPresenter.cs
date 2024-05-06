using Source.Game;
using Source.Player;
using Source.UI;
using Source.UI.Mono;
using Source.Weapon.Mono;
using UnityEngine;
using VContainer.Unity;

namespace Source.Weapon
{
    public class WeaponPresenter : IStartable, IFixedTickable
    {
        private readonly BulletPool _bulletPool;
        private readonly CoinFactory _coinFactory;

        private readonly TouchInputTarget _touchInputTarget;
        private readonly BulletMove _bulletMove;
        private readonly GameStats _gameStats;

        private Camera _camera;

        private WeaponPresenter(BulletPool bulletPool, TouchInputTarget touchInputTarget, BulletMove bulletMove, 
            ArcherAnimation archerAnimation, GameStats gameStats, CoinFactory coinFactory)
        {
            _bulletPool = bulletPool;
            _touchInputTarget = touchInputTarget;
            _bulletMove = bulletMove;
            _gameStats = gameStats;
            _coinFactory = coinFactory;
            archerAnimation.OnShoot += SpawnBullet;
        }

        public void Start()
        {
            _camera = Camera.main;
        }

        public void FixedTick()
        {
            _bulletMove.Move();
        }
        
        private void SpawnBullet()
        {
            BulletView newBulletView = _bulletPool.Pool.Get();
            newBulletView.Init(-_touchInputTarget.Direction);
            newBulletView.OnArrowHit += OnArrowHit;
            _bulletMove.AddBullet(newBulletView);
        }

        private void OnArrowHit(BulletView bulletView)
        {
            bulletView.OnArrowHit -= OnArrowHit;
            _gameStats.CollectCoin();
            _coinFactory.Create(_camera.WorldToScreenPoint(bulletView.Transform.position));
            _bulletPool.Pool.Release(bulletView);
        }
    }
}
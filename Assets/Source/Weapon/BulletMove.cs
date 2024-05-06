using System.Collections.Generic;
using Source.Player.Mono;
using Source.Weapon.Mono;
using UnityEngine;
using VContainer;

namespace Source.Weapon
{
    public class BulletMove
    {
        [Inject] private readonly ArcherView _archerView;
        private Transform _aimLineTransform;
        
        private List<BulletView> _bulletViews = new List<BulletView>();

        private BulletMove(ArcherView archerView)
        {
            _archerView = archerView;
            _aimLineTransform = _archerView.AimLine.transform;
        }
        
        public void AddBullet(BulletView bulletView)
        {
            _bulletViews.Add(bulletView);
            bulletView.SetStartPosition(_aimLineTransform.position);
            bulletView.OnArrowHit += OnArrowHit;
        }

        private void OnArrowHit(BulletView bulletView)
        {
            _bulletViews.Remove(bulletView);
        }

        public void Move()
        {
            if (_bulletViews.Count > 0)
            {
                foreach (var bulletView in _bulletViews)
                {
                    bulletView.Move();
                }
            }
        }
    }
}
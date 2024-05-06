using System;
using Source.Player.Mono;
using Spine;
using VContainer;

namespace Source.Player
{
    public class ArcherAnimation
    {
        [Inject] private readonly ArcherView _archerView;

        public Action OnShoot;
        
        public void StartAiming()
        {
            _archerView.SkeletonAnimation.AnimationState.SetAnimation(0, "attack_start", false);
            _archerView.SkeletonAnimation.AnimationState.AddAnimation(0, "attack_target", true, 0);
        }

        public void AttackFinish()
        {
            TrackEntry trackEntry = _archerView.SkeletonAnimation.AnimationState.AddAnimation(0, "attack_finish", false, 0);
            trackEntry.Event += TrackEntryOnEvent;
            _archerView.SkeletonAnimation.AnimationState.AddAnimation(0, "idle", true, 0);
        }

        private void TrackEntryOnEvent(TrackEntry trackentry, Event e)
        {
            if (e.Data == _archerView.ShootEvent)
            {
                OnShoot?.Invoke();
            }
        }
    }
}
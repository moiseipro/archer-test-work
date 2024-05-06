using Source.Player.Mono;
using UnityEngine;
using VContainer;

namespace Source.Player
{
    public class ArcherTarget
    {
        [Inject] private readonly ArcherView _archerView;
        
        public void TargetUpdate(Vector2 direction)
        {
            var skeletonSpacePoint = -direction;
            skeletonSpacePoint.x *= _archerView.SkeletonAnimation.Skeleton.ScaleX;
            skeletonSpacePoint.y *= _archerView.SkeletonAnimation.Skeleton.ScaleY;
            float rotateAngle = Mathf.Clamp(Vector2.SignedAngle(_archerView.Transform.right, skeletonSpacePoint),
                _archerView.MinAimAngle, _archerView.MaxAimAngle);
            _archerView.Bone.Rotation = rotateAngle;

            Vector2 clampedDirection = new Vector2(Mathf.Cos(rotateAngle * Mathf.Deg2Rad), Mathf.Sin(rotateAngle * Mathf.Deg2Rad));
            _archerView.AimLine.CalculatePoints(clampedDirection * direction.magnitude);
        }

        public void StartAim()
        {
            _archerView.AimLine.Activate();
        }
        
        public void EndAim()
        {
            _archerView.AimLine.Deactivate();
        }
    }
}
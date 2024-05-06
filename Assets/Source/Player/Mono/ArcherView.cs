using Spine;
using Spine.Unity;
using UnityEngine;

namespace Source.Player.Mono
{
    public class ArcherView : MonoBehaviour
    {
        [Range(0, 90f)] [SerializeField] private float maxAimAngle;
        public float MaxAimAngle => maxAimAngle;
        [Range(-75, 0)] [SerializeField] private float minAimAngle;
        public float MinAimAngle => minAimAngle;

        [SpineBone(dataField:"skeletonAnimation")]
        public string boneName;
        private Bone _bone;
        public Bone Bone => _bone;

        [SerializeField] private string shootEventName;
        private EventData _shootEvent;
        public EventData ShootEvent => _shootEvent;

        [SerializeField] private SkeletonAnimation skeletonAnimation;
        public SkeletonAnimation SkeletonAnimation => skeletonAnimation;
        [SerializeField] private AimLine aimLine;
        public AimLine AimLine => aimLine;
        private Transform _transform;
        public Transform Transform => _transform;

        private void Awake()
        {
            skeletonAnimation = GetComponent<SkeletonAnimation>();
            aimLine = GetComponentInChildren<AimLine>();
            _transform = transform;
        }
    
        private void Start()
        {
            _bone = skeletonAnimation.Skeleton.FindBone(boneName);
            _shootEvent = skeletonAnimation.Skeleton.Data.FindEvent(shootEventName);
        }
    }
}
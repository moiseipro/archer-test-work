using Source.UI;
using Source.UI.Mono;
using VContainer;
using VContainer.Unity;

namespace Source.Player
{
    public class PlayerPresenter : IStartable, ITickable
    {
        private readonly TouchInputTarget _touchInputTarget;
        private readonly ArcherTarget _archerTarget;
        private readonly ArcherAnimation _archerAnimation;


        [Inject]
        private PlayerPresenter(TouchInputTarget touchInputTarget, ArcherTarget archerTarget, ArcherAnimation archerAnimation)
        {
            _touchInputTarget = touchInputTarget;
            _archerTarget = archerTarget;
            _archerAnimation = archerAnimation;
            _touchInputTarget.OnStartTarget += OnStartTarget;
            _touchInputTarget.OnEndTarget += OnEndTarget;
        }

        private void OnEndTarget()
        {
            _archerAnimation.AttackFinish();
            _archerTarget.EndAim();
        }

        private void OnStartTarget()
        {
            _archerAnimation.StartAiming();
            _archerTarget.StartAim();
        }

        public void Start()
        {
            
        }

        public void Tick()
        {
            _archerTarget.TargetUpdate(_touchInputTarget.Direction);
        }
    }
}
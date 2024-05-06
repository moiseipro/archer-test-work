using Source.Player.Mono;
using Source.UI.Mono;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.UI
{
    public class UIPresenter : IStartable, ITickable
    {
        private readonly TouchInputTarget _touchInputTarget;
        private readonly ArcherView _archerView;
        
        private Camera _camera;
        
        
        [Inject]
        private UIPresenter(TouchInputTarget touchInputTarget, ArcherView archerView)
        {
            _touchInputTarget = touchInputTarget;
            _archerView = archerView;
        }

        public void Start()
        {
            _camera = Camera.main;
        }

        public void Tick()
        {
            Vector2 newPosition = _camera.WorldToScreenPoint(_archerView.Transform.position);
            _touchInputTarget.SetPosition(newPosition);
        }
    }
}
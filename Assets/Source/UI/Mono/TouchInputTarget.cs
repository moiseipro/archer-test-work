using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Source.UI.Mono
{
    public class TouchInputTarget : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IUIOnTarget
    {
        [SerializeField] private float maximumDeviation;
        private Vector2 _startScreenPosition;
        private Vector2 _direction;
        public Vector2 Direction => _direction;

        private RectTransform _transform;

        public Action<Vector2> OnTargetUpdate;
        public Action OnStartTarget, OnEndTarget;

        private void Awake()
        {
            _transform = GetComponent<RectTransform>();
        }

        public void SetPosition(Vector3 position)
        {
            _transform.position = position;
        }
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startScreenPosition = _transform.position;
            OnStartTarget?.Invoke();
            Debug.Log("Start aiming: " + _startScreenPosition);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnEndTarget?.Invoke();
            Debug.Log("Stop aiming");
        }

        public void OnDrag(PointerEventData eventData)
        {
            _direction = Vector2.ClampMagnitude((eventData.position - _startScreenPosition) / maximumDeviation, 1f);
            OnTargetUpdate?.Invoke(_direction);
            //Debug.Log("Aiming: " + _direction);
        }
    }
}
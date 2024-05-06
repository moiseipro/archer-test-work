using System;
using Source.Game;
using UnityEngine;

namespace Source.Weapon.Mono
{
    public class BulletView : MonoBehaviour
    {
        private Transform _transform;
        public Transform Transform => _transform;
        private Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        [SerializeField] private float bulletSpeed = 10f;

        private Vector2 _direction;
        public Vector2 Direction => _direction;
        private Vector2 _startPosition;
        public Vector2 StartPosition => _startPosition;
        private Vector2 _currentPosition;

        public Action<BulletView> OnArrowHit;

        private void Awake()
        {
            _transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Init(Vector2 direction)
        {
            _direction = direction;
        }

        public void SetStartPosition(Vector2 position)
        {
            _currentPosition = Vector2.zero;
            _startPosition = position;
            _transform.position = _startPosition;
            _rigidbody2D.MovePosition(_startPosition);
            _rigidbody2D.isKinematic = false;
        }

        public void Move()
        {
            Vector2 lerpPosition = Vector2.MoveTowards(_rigidbody2D.position, _startPosition + _currentPosition, Time.deltaTime * bulletSpeed);
            if (Vector2.Distance(lerpPosition, _startPosition + _currentPosition) < 0.1f)
            {
                Vector2 newPosition = UtilityMath.GetNextAimPoint(_currentPosition, _direction);
                Debug.DrawLine(_startPosition + _currentPosition, _startPosition + newPosition, Color.red, 1f);
                _currentPosition = newPosition;
            }

            _rigidbody2D.MovePosition(lerpPosition);
            _rigidbody2D.SetRotation(Vector2.SignedAngle(Vector2.right, _currentPosition));
        }
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            _rigidbody2D.isKinematic = true;
            OnArrowHit?.Invoke(this);
        }
    }
}
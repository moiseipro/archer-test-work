using Source.Game;
using UnityEngine;

namespace Source.Player.Mono
{
    public class AimLine : MonoBehaviour
    {
        [SerializeField] private Transform aimPointPrefab;
        [SerializeField] private int aimPointCount = 5;
        [SerializeField] private float aimDistance = 5f;

        private Transform[] _aimPoints;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
            _aimPoints = new Transform[aimPointCount];
            for (int i = 0; i < _aimPoints.Length; i++)
            {
                _aimPoints[i] = Instantiate(aimPointPrefab, _transform.position, Quaternion.identity, _transform);
            }
            Deactivate();
        }

        public void CalculatePoints(Vector2 direction)
        {
            Vector2 startPosition = (Vector2)_transform.position;
            Vector2 startPoint = Vector2.zero;
            Vector2 currentPoint = startPoint;
            RaycastHit2D raycastHit2D =
                Physics2D.Raycast(startPoint, direction, direction.magnitude * aimDistance, 1 << 6);
            if (raycastHit2D)
            {
                
            }

            int i = 0;
            while (Mathf.Abs(startPoint.x-currentPoint.x)<aimDistance)
            {
                Vector2 nextPoint = UtilityMath.GetNextAimPoint(currentPoint, direction);
                Debug.DrawLine(currentPoint + startPosition, nextPoint + startPosition);
                currentPoint = nextPoint;
                if (i < _aimPoints.Length)
                {
                    _aimPoints[i].position = currentPoint + startPosition;
                    i++;
                }
            }
        }

        public void Activate()
        {
            for (int i = 0; i < _aimPoints.Length; i++)
            {
                _aimPoints[i].gameObject.SetActive(true);
            }
        }

        public void Deactivate()
        {
            for (int i = 0; i < _aimPoints.Length; i++)
            {
                _aimPoints[i].gameObject.SetActive(false);
            }
        }
    }
}
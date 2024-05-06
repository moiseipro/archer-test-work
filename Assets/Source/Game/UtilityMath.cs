using UnityEngine;

namespace Source.Game
{
    public static class UtilityMath
    {
        private static float _gravityCoefficient = 1.1f;
        private static float _power = 6f;

        public static Vector2 GetNextAimPoint(Vector2 currentPoint, Vector2 direction)
        {
            Vector2 newPoint = new Vector2(currentPoint.x + Mathf.Clamp(direction.x, 0.1f, 1f), currentPoint.y + direction.y - currentPoint.x / _power * (_gravityCoefficient - direction.x));
            return newPoint;
        }
    }
}
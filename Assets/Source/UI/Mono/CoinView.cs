using UnityEngine;

namespace Source.UI.Mono
{
    public class CoinView : MonoBehaviour
    {
        private RectTransform _rectTransform;
        
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void SetPosition(Vector2 position)
        {
            _rectTransform.position = position;
        }
    }
}
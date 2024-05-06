using DG.Tweening;
using Source.Game;
using Source.UI.Mono;
using TMPro;
using UnityEngine;
using VContainer;

namespace Source.UI
{
    public class MoneyCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private Transform _iconTransform;
        [SerializeField] private float _coinAnimationTime = 2f;
        [SerializeField] private float _coinKillTime = 0.3f;

        private CoinFactory _coinFactory;
        
        private int _currentValue;
        private Sequence _sequence;
        private Transform _transform;
        
        [Inject]
        public void Container(GameStats gameStats, CoinFactory coinFactory)
        {
            _coinFactory = coinFactory;
            coinFactory.OnCreatedCoin += StartAnimation;
            gameStats.OnCollectCoin += UpdateCoinValue;
            UpdateCoinValue(gameStats.Money);
            UpdateCoinText();
        }

        private void Awake()
        {
            _transform = transform;
        }

        private void StartAnimation(CoinView coinView)
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(coinView.GetComponent<RectTransform>().DOMove(_iconTransform.position, _coinAnimationTime));
            _sequence.AppendInterval(_coinKillTime);
            _sequence.AppendCallback(() =>
            {
                _coinFactory.ReturnToPool(coinView);
                UpdateCoinText();
            });
        }
        
        private void UpdateCoinValue(int value)
        {
            _currentValue = value;
        }
        
        private void UpdateCoinText()
        {
            _tmpText.text = _currentValue.ToString();
        }
    }
}
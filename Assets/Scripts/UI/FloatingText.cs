using UnityEngine;
using TMPro;
using DG.Tweening;
using Zenject;

namespace UI
{
    public class FloatingText : MonoBehaviour, IPoolable<string, Vector3, IMemoryPool>
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        [SerializeField]
        private float _duration = 1f;
        [SerializeField]
        private Vector3 _moveBy = new Vector3(0, 1f, 0);
        [SerializeField]
        private float _startScale = 1f;
        [SerializeField]
        private float _endScale = 1.15f;
        [SerializeField]
        private Ease _moveEase = Ease.OutCubic;
        [SerializeField]
        private Ease _scaleEase = Ease.OutBack;

        private Sequence _sequence;
        private IMemoryPool _pool;

        private void OnDestroy()
        {
            _sequence?.Kill();
        }

        public void OnSpawned(string message, Vector3 position, IMemoryPool pool)
        {
            _pool = pool;

            _text.text = message;
            transform.position = position;
            transform.localScale = Vector3.one * _startScale;

            _sequence = DOTween.Sequence();

            _sequence.Join(transform.DOMove(transform.position + _moveBy, _duration).SetEase(_moveEase));
            _sequence.Join(transform.DOScale(_endScale, _duration * 0.6f).SetEase(_scaleEase));

            _sequence.OnComplete(() => _pool.Despawn(this));
        }

        public void OnDespawned()
        {
            _pool = null;
        }

        public class Factory : PlaceholderFactory<string, Vector3, FloatingText>
        {
        }
    }
}

using TMPro;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private float _changeSpeed;

        private float _maxValue = 1;
        private float _currentValue = 1;

        private const float MinValue = 0;

        private void Start()
        {
            SetMax(100f);

            SetValue(40f);
        }

        public void SetMax(float value)
        {
            if (value <= 0) return;

            _currentValue *= value / _maxValue;
            _maxValue = value;
        }

        public void SetValue(float value)
        {
            var clampedValue = Mathf.Clamp(value, MinValue, _maxValue);

            float fillValue = clampedValue / _maxValue;

            _fill.DOFillAmount(fillValue, _changeSpeed);

            DOTween.To(() => _currentValue, (value) => _text.SetText($"{(int)value} / {_maxValue}"), clampedValue, _changeSpeed);
        }

    }
}
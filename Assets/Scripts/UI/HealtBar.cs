using TMPro;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;
using System;

namespace DarkLegion.UI
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private float _changeSpeed;

        public event Action Emptied;

        private float _maxValue = 1;
        private float _currentValue = 1;

        private const float MinValue = 0;

        public void SetMax(float value)
        {
            if (value <= 0) return;

            _currentValue *= value / _maxValue;
            _maxValue = value;
            ChangeText(_currentValue);
        }

        public void SetValue(float value)
        {
            float clampedValue = Mathf.Clamp(value, MinValue, _maxValue);

            float fillValue = (float)clampedValue / _maxValue;

            _fill.DOFillAmount(fillValue, _changeSpeed);

            DOTween.To(() => _currentValue, ChangeText, clampedValue, _changeSpeed)
                .OnComplete(() =>
                {
                    _currentValue = clampedValue;
                    if (_currentValue == MinValue)
                    {
                        Emptied?.Invoke();
                    }
                });

        }

        private void ChangeText(float value)
        {
            _text.SetText($"{string.Format("#.00", value)} / {_maxValue}");
        }

    }
}
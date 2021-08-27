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

        private int _maxValue = 1;
        private int _currentValue = 1;

        private const int MinValue = 0;

        public void SetMax(int value)
        {
            if (value <= 0) return;

            _currentValue *= value / _maxValue;
            _maxValue = value;
            ChangeText(_currentValue);

            SetValue(0);
        }

        public void SetValue(int value)
        {
            int clampedValue = Mathf.Clamp(value, MinValue, _maxValue);

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

        private void ChangeText(int value)
        {
            _text.SetText($"{value} / {_maxValue}");
        }

    }
}
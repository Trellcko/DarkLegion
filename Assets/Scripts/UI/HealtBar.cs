using TMPro;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;
using System;
using DarkLegion.Core;

namespace DarkLegion.UI
{
    public class HealtBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private float _changeSpeed;

        private IValueChanged _target;
        private Action _valueChangedHandelr;

        private float _maxValue = 1;
        private float _currentValue = 1;

        private const float MinValue = 0;

        private void Awake()
        {
            _valueChangedHandelr += () => { SetValue(_target.GetValue()); };
        }

        private void OnEnable()
        {
            if (_target != null)
            {
                _target.Changed += _valueChangedHandelr;
            }
        }

        private void OnDisable()
        {

            if (_target != null)
            {
                _target.Changed -= _valueChangedHandelr;
            }
        }

        public void SetMax(float value)
        {
            if (value <= 0) return;

            _currentValue *= value / _maxValue;
            _maxValue = value;
            ChangeText(_currentValue);
        }

        public void SetTarget(IValueChanged target)
        {
           if(_target != null)
            {
                _target.Changed -= _valueChangedHandelr;
            }
            _target = target;
            _target.Changed += _valueChangedHandelr;
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
                });

        }

        private void ChangeText(float value)
        {
            _text.SetText($"{string.Format("{0:0}", value)} / {_maxValue}");
        }

    }
}
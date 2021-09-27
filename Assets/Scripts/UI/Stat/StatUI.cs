using UnityEngine;

using TMPro;

using DarkLegion.Core.Visualization;
using DarkLegion.Unit.Stat;
using DarkLegion.Field;
using DarkLegion.Unit;
using System;

namespace DarkLegion.UI
{
    public abstract class StatUI<T> : MonoBehaviour where T : BaseStat
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TurnSystem _turnSystem;

        private Action _turnChangedHandler;
        private T _stat;

        private void Awake()
        {
            _turnChangedHandler += () =>
            {
                if (_stat)
                {
                    _stat.Changed -= ShowStatActiveUnit;
                }
                _stat = GetNeedStat(_turnSystem.ActiveUnit);
                _stat.Changed += ShowStatActiveUnit;
                ShowStatActiveUnit();
            };
        }

        private void OnEnable()
        {
            _turnSystem.TurnChanged += _turnChangedHandler;
            
        }
        private void OnDisable()
        {
            _turnSystem.TurnChanged -= _turnChangedHandler;
        }

        private void ShowStatActiveUnit()
        {
            float currentStatValue = GetNeedStat(_turnSystem.ActiveUnit).Value;
            float baseStatValue = GetBaseStatValue(_turnSystem.ActiveUnit.BaseInfo);


            _text.SetText(string.Format("{0:0}", currentStatValue));
            if(!Mathf.Approximately(currentStatValue, baseStatValue))
            {
                if(currentStatValue > baseStatValue)
                {
                    ShowBuffVisualization();
                    return;
                }
                ShowDeBuffVisualization();
            }

        }

        public abstract T GetNeedStat(ComponentStorage unit);

        public abstract float GetBaseStatValue(BaseInfo baseInfo);

        public void SetValue(string text)
        {
            _text.SetText(text);
        }

        public void ShowBuffVisualization()
        {
            _text.color = GameColors.Buff;
        }
        public void ShowDeBuffVisualization()
        {
            _text.color = GameColors.DeBuff;
        }
    }
}
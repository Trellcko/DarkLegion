using DarkLegion.Field;
using System;
using UnityEngine;

namespace DarkLegion.UI
{
    public class InfoTableHealthBar : MonoBehaviour
    {
        [SerializeField] private HealtBar _healtBar;
        
        [SerializeField] private TurnSystem _turnSystem;

        private Action _turnChangedHandler;
        private void Awake()
        {
            _turnChangedHandler += () =>
            {
                _healtBar.SetMax(_turnSystem.ActiveUnit.BaseInfo.Health);
                _healtBar.SetTarget(_turnSystem.ActiveUnit.Health.GetValueChanged());
                _healtBar.SetValue(_turnSystem.ActiveUnit.Health.GetValueChanged().GetValue());
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
    }
}
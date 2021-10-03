using DarkLegion.Field;
using System;
using UnityEngine;

namespace DarkLegion.UI
{
    public class InfoTableHealthBarHandler : MonoBehaviour
    {
        [SerializeField] private HealtBar _healtBar;
        
        [SerializeField] private TurnSystem _turnSystem;

        private void SetActiveUnitHealt()
        {
            _healtBar.SetMax(_turnSystem.ActiveUnit.BaseInfo.Health);
            _healtBar.SetTarget(_turnSystem.ActiveUnit.Health.GetValueChanged());
            _healtBar.SetValue(_turnSystem.ActiveUnit.Health.GetValueChanged().GetValue());
        }

        private void OnEnable()
        {
            _turnSystem.TurnChanged += SetActiveUnitHealt;
        }
        private void OnDisable()
        {
            _turnSystem.TurnChanged -= SetActiveUnitHealt;
        }
    }
}
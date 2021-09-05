using DarkLegion.Unit;

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace DarkLegion.Field
{
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField] private List<ComponentStorage> _units;

        [SerializeField] private LayerMask _playerUnitMask;
        [SerializeField] private LayerMask _enemyUnitMask;

        public bool IsPlayerTurn { get; private set; } = false;
        public ComponentStorage ActiveUnit { get; private set; } = null;

        public event Action TurnChanged;

        private void Awake()
        {
            _units = FindObjectsOfType<ComponentStorage>().ToList();
        }

        private void Start()
        {
            ChangeTurn();
        }

        public void ChangeTurn()
        {
            ComponentStorage unitWithMoreInitiative = FindUnitWithHigherInitiative();
            unitWithMoreInitiative.Initiative.Set(unitWithMoreInitiative.Initiative.Value - 5);

            foreach (var unit in _units)
            {
                unit.Initiative.Set(unit.Initiative.Value + 1);
            }
            IsPlayerTurn = unitWithMoreInitiative.gameObject.layer == _playerUnitMask;
            ActiveUnit = unitWithMoreInitiative;
            TurnChanged?.Invoke();
          
        }
        private ComponentStorage FindUnitWithHigherInitiative()
        {
            if (_units == null)
            {
                return null;
            }
            ComponentStorage result = _units[0];

            foreach(var unit in _units)
            {
                if(unit.Initiative.Value > result.Initiative.Value)
                {
                    result = unit;
                }
            }

            return result;
        }
    }
}
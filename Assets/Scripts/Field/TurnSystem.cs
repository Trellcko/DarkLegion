using DarkLegion.Field.Visuzalization;
using DarkLegion.Unit;

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace DarkLegion.Field
{
    public enum Turn { Player, Enemy, None}

    public class TurnSystem : MonoBehaviour
    {
        [SerializeField] private TurnVisualization _turnVisualization;

        [SerializeField] private LayerMask _playerUnitMask;

        public bool IsPlayerTurn => _currentTurnBelongTo == Turn.Player;
        public bool IsEnemyTurn => _currentTurnBelongTo == Turn.Enemy;

        public ComponentStorage ActiveUnit { get; private set; } = null;

        public event Action TurnChanged;

        private List<ComponentStorage> _units;

        List<ComponentStorage> _activeUnits = new List<ComponentStorage>();

        private Turn _currentTurnBelongTo = Turn.None;

        private void Awake()
        {
            _units = FindObjectsOfType<ComponentStorage>().ToList();
        }

        private void Start()
        {
            ChangeActiveUnit();
            TurnChanged?.Invoke();
            _turnVisualization.Visualize(UnitExtension.SortByInitiative(_units));
        }

        public void ChangeTurn()
        {
            _currentTurnBelongTo = Turn.None;
            VisualizeTurnChange();
        }

        private void VisualizeTurnChange()
        {
            List<ComponentStorage> activeUnitsWithMoreInitiative = UnitExtension.SortByInitiative(_activeUnits);
            _turnVisualization.MoveToStart(0, activeUnitsWithMoreInitiative, UnitExtension.SortByInitiative(_units), () => 
            {
                ChangeActiveUnit();
                TurnChanged?.Invoke(); 
            });
        }

        private void ChangeActiveUnit()
        {
            if (ActiveUnit)
            {
                _activeUnits.Remove(ActiveUnit);
                ActiveUnit.ActionPoints.Emptied -= ChangeTurn;
                ActiveUnit.ActionPoints.Dispose();
            }

            if (_activeUnits.Count == 0)
            {
                _activeUnits = new List<ComponentStorage>(_units);
            }

            _activeUnits = UnitExtension.SortByInitiative(_activeUnits);

            _currentTurnBelongTo = LayerExtension.ContainsIn(_playerUnitMask, _activeUnits[0].gameObject.layer)? Turn.Player : Turn.Enemy;

            ActiveUnit = _activeUnits[0];
            ActiveUnit.ActionPoints.Emptied += ChangeTurn;
        }

    }
}
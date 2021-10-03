using DarkLegion.Field.Visuzalization;
using DarkLegion.Unit;

using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace DarkLegion.Field
{
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField] private TurnVisualization _turnVisualization;

        [SerializeField] private LayerMask _playerUnitMask;
       
        public bool IsPlayerTurn { get; private set; } = false;

        public ComponentStorage ActiveUnit { get; private set; } = null;

        public event Action TurnChanged;

        private List<ComponentStorage> _units;

        List<ComponentStorage> _activeUnits = new List<ComponentStorage>();

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
            VisualizeTurnChange();
        }

        private void VisualizeTurnChange()
        {
            List<ComponentStorage> unitsWithMoreInitiative = UnitExtension.SortByInitiative(_activeUnits);

            _turnVisualization.MoveToStart(0, unitsWithMoreInitiative, UnitExtension.SortByInitiative(_units), () => 
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

            IsPlayerTurn = LayerExtension.ContainsIn(_playerUnitMask, _activeUnits[0].gameObject.layer);

            ActiveUnit = _activeUnits[0];
            ActiveUnit.ActionPoints.Emptied += ChangeTurn;
        }

    }
}
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

        List<ComponentStorage> _activeUnits;

        private Dictionary<ComponentStorage, bool> _unitsActivity = new Dictionary<ComponentStorage, bool>();

        private void Awake()
        {
            _units = FindObjectsOfType<ComponentStorage>().ToList();
            for(int i = 0; i < _units.Count; i++)
            {
                _unitsActivity.Add(_units[i], true);
            }
        }

        private void Start()
        {
            ChangeActiveUnit();
            TurnChanged?.Invoke();
            _turnVisualization.Visualize(UnitExtension.SortByInitiative(_units));
        }

        public void ChangeTurn()
        {
            ChangeActiveUnit();
            VisualizeTurnChange();

            TurnChanged?.Invoke();
        }

        private void VisualizeTurnChange()
        {
            List<ComponentStorage> unitsWithMoreInitiative = UnitExtension.SortByInitiative(_activeUnits);

            _turnVisualization.MoveToStart(0, unitsWithMoreInitiative, UnitExtension.SortByInitiative(_units));
        }

        private void ChangeActiveUnit()
        {
            if (ActiveUnit)
            {
                _unitsActivity[ActiveUnit] = false;
                ActiveUnit.ActionPoints.Emptied -= ChangeTurn;
                ActiveUnit.ActionPoints.Dispose();
            }

            _activeUnits = _unitsActivity.Where(x => x.Value == true).Select(x => x.Key).ToList();

            if (_activeUnits.Count == 0)
            {
                foreach (var unit in _units)
                {
                    _unitsActivity[unit] = true;
                }
                _activeUnits = _units;
            }

            _activeUnits = UnitExtension.SortByInitiative(_activeUnits);

            IsPlayerTurn = LayerExtension.ContainsIn(_playerUnitMask, _activeUnits[0].gameObject.layer);

            ActiveUnit = _activeUnits[0];
            ActiveUnit.ActionPoints.Emptied += ChangeTurn;
        }

    }
}
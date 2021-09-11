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
            ChangeTurn();
        }

        public void ChangeTurn()
        {   
            if(ActiveUnit)
            {
                _unitsActivity[ActiveUnit] = false;
            }
            
            List<ComponentStorage> activeUnits = _unitsActivity.Where(x => x.Value == true).Select(x=>x.Key).ToList();
            List<ComponentStorage> nonActiveUnits = _unitsActivity.Where(x => x.Value == false).Select(x => x.Key).ToList();

            if (activeUnits.Count == 0)
            {
                foreach(var unit in _units)
                {
                    _unitsActivity[unit] = true;
                }
                activeUnits = _units;
            }
            
            List<ComponentStorage> unitsWithMoreInitiative = UnitExtension.SortByInitiative(activeUnits);
            List<ComponentStorage> nonActiveUnitsWithMoreInitiative = UnitExtension.SortByInitiative(nonActiveUnits);

            _turnVisualization.Visualize(unitsWithMoreInitiative, UnitExtension.SortByInitiative(_units ));

            IsPlayerTurn = LayerExtension.ContainsIn(_playerUnitMask, unitsWithMoreInitiative[0].gameObject.layer);

            ActiveUnit = unitsWithMoreInitiative[0];

            TurnChanged?.Invoke();
        }
    }
}
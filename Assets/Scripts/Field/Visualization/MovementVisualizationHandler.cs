using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class MovementVisualizationHandler : MonoBehaviour
    {
        [SerializeField] private PlayerCommander _playerCommander;
        [SerializeField] private TurnSystem _turnSystem;

        [SerializeField] private PathVisualization _pathVisualization;
        [SerializeField] private MovementCellVisualization _movementCellVisualization;

        private Action _turnChangedHandler;
        private Action<bool> _unitMovedHandler;

        private void OnEnable()
        {
            _playerCommander.UnitMoving += TurnOff;
            _turnSystem.TurnChanged += _turnChangedHandler;
            _playerCommander.UnitMoved += _unitMovedHandler;
        }

        private void OnDisable()
        {
            _playerCommander.UnitMoving -= TurnOff;
            _turnSystem.TurnChanged -= _turnChangedHandler;
            _playerCommander.UnitMoved -= _unitMovedHandler;
        }

        private void Awake()
        {
            _unitMovedHandler += (hasPoints) => { if (hasPoints) TurnOn(); };
            _turnChangedHandler += () => { if (_turnSystem.IsPlayerTurn) TurnOn(); };
        }

        private void TurnOff()
        {
            _pathVisualization.StopDraw();
            _movementCellVisualization.ClearLastVisualize();
        }

        private void TurnOn()
        {
            _movementCellVisualization.Show(_turnSystem.ActiveUnit.transform.position,
                                           (int)_turnSystem.ActiveUnit.Movement.Value);
            _pathVisualization.StartDraw();
        }
    }
}
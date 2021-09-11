using DarkLegion.Input;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Utils;
using DarkLegion.Field;

using System.Collections.Generic;

using UnityEngine;
using DarkLegion.Core.Visualization;
using System;

namespace DarkLegion.Field.Visuzalization
{
    public class PathVisualization : MonoBehaviour
    {
        [SerializeField] private TurnSystem _turnSystem;

        [SerializeField] private PathDrawer _drawer;

        [SerializeField] private Pathfinder _pathfinder;

        [SerializeField] private GridHandler _gridHandler;

        private Vector3Int _lastMouseCellPosition = Vector3Int.zero;

        private bool _isDrawingPath = false;

        private Action _turnChangedHandler;

        private void Awake()
        {
            _turnChangedHandler = () =>
            {
                if (_turnSystem.IsPlayerTurn)
                {
                    StartDraw();
                    return;
                }
                StopDraw();
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

        private void Update()
        {
            if (_isDrawingPath && _gridHandler.GetCell(InputHandler.Instance.GetMousePosition()) != _lastMouseCellPosition)
            {
                Vector2 mousePosition = InputHandler.Instance.GetMousePosition();
                
                _lastMouseCellPosition = _gridHandler.GetCell(mousePosition);
                
                var path = _pathfinder.FindPath(_turnSystem.ActiveUnit.transform.position,
                    mousePosition);

                var dotsData = new Dictionary<Vector3, Color>();

                for (int i = 0; i < path.Count; i++)
                {
                    var color = _turnSystem.ActiveUnit.Movement.Value > i ? GameColors.Movement : GameColors.Attack;
                    dotsData.Add(path[i], color);
                }

                _drawer.Draw(dotsData);
            }
        }

        public void StartDraw()
        {
            _isDrawingPath = true;
        }

        public void StopDraw()
        {
            _isDrawingPath = false;
            _drawer.Erase();
        }

    }
}
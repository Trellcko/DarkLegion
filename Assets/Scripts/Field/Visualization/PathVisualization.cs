using DarkLegion.Input;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Utils;
using DarkLegion.Field;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class PathVisualization : MonoBehaviour
    {
        [SerializeField] private UnitSelecting _playerUnitSelecting;
        [SerializeField] private TransformSelecting _everythingSelecting;

        [SerializeField] private PathDrawer _drawer;

        [SerializeField] private Pathfinder _pathfinder;

        [SerializeField] private GridHandler _gridHandler;

        private Vector3Int _lastMouseCellPosition = Vector3Int.zero;

        private bool _isDrawingPath = false;

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += StopDraw; ;
            _playerUnitSelecting.Selected += StartDraw;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= StopDraw;
            _playerUnitSelecting.Selected -= StartDraw;
        }

        private void Update()
        {
            if (_isDrawingPath && _gridHandler.GetCell(InputHandler.Instance.GetMousePosition()) != _lastMouseCellPosition)
            {
                Vector2 mousePosition = InputHandler.Instance.GetMousePosition();
                
                _lastMouseCellPosition = _gridHandler.GetCell(mousePosition);
                
                var path = _pathfinder.FindPath(_playerUnitSelecting.LastSelected.transform.position,
                    mousePosition);

                var dotsData = new Dictionary<Vector3, Color>();

                for (int i = 0; i < path.Count; i++)
                {
                    var color = _playerUnitSelecting.LastSelected.Data.MaxStep > i ? Color.green : Color.red;
                    dotsData.Add(path[i], color);
                }

                _drawer.Draw(dotsData);
            }
        }

        private void StartDraw()
        {
            _isDrawingPath = true;
        }

        private void StopDraw()
        {
            _isDrawingPath = false;
            _drawer.Erase();
        }

    }
}
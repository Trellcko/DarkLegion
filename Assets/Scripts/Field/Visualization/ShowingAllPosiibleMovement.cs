using DarkLegion.Field.Pathfinding;
using DarkLegion.Units;
using DarkLegion.Utils;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Visuzalization
{
    public class ShowingAllPosiibleMovement : MonoBehaviour
    {
        [SerializeField] private GraphGenerator _graphGenerator;
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private UnitSelecting _playerUnitSelecting;
        [SerializeField] private TransformSelecting _everythingSelecting;

        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private Color _movement;

        private List<PathNode> _currentIterationNodes;
        private List<PathNode> _nextIterationNodes;

        private List<PathNode> _possibleNodes;

        private int _maxDepth;
        private int _currentDepth = 0;

        private void OnEnable()
        {
            _everythingSelecting.UnSelected += ClearLastVisualize;
            _playerUnitSelecting.Selected += PlayerUnitSelected;
        }

        private void OnDisable()
        {
            _everythingSelecting.UnSelected -= ClearLastVisualize;
            _playerUnitSelecting.Selected += PlayerUnitSelected;
        }

        private void PlayerUnitSelected()
        {
            Show(_playerUnitSelecting.LastSelected.transform.position, _playerUnitSelecting.LastSelected.UnitData.MaxStep);
        }

        private void Show(Vector3 startPosition, int depth)
        {
            ClearLastVisualize();
         
            _maxDepth = depth;
            _currentDepth = 0;
            _nextIterationNodes = new List<PathNode>();
            _possibleNodes = new List<PathNode>();

            _currentIterationNodes = new List<PathNode>() {
                _graphGenerator.Graph.GetPathNode(_gridHandler.GetCell(startPosition))
            };
            DoNextIteration();
        }

        private void DoNextIteration()
        {
            _currentDepth++;
            if(_currentDepth > _maxDepth)
            {
                Visualize(_possibleNodes);
                return;
            }

            for(int i = 0; i < _currentIterationNodes.Count; i++)
            {
                if(_possibleNodes.Contains(_currentIterationNodes[i]) == false)
                {
                    _possibleNodes.Add(_currentIterationNodes[i]);
                    
                    for(int  j = 0; j < _currentIterationNodes[i].Neighbors.Count; j++)
                    {
                        _nextIterationNodes.Add(_currentIterationNodes[i].Neighbors[j]);
                    }
                }
            }
            _currentIterationNodes = _nextIterationNodes;
            _nextIterationNodes = new List<PathNode>();
            DoNextIteration();
        }

        private void Visualize(List<PathNode> pathNodes)
        {
            SetColors(pathNodes, _movement);
        }

        private void SetColors(List<PathNode> pathNodes, Color color)
        {
            pathNodes?.ForEach(pathnode =>
            {
                _tilemap.SetColor(pathnode.Coordinates, color);
            });
        }

        private void ClearLastVisualize()
        {
            SetColors(_possibleNodes, Color.white);
        }

    }
}
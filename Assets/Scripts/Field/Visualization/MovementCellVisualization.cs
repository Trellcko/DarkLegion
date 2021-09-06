using DarkLegion.Core.Visualization;
using DarkLegion.Field.Pathfinding;
using DarkLegion.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{

    public class MovementCellVisualization : MonoBehaviour
    {
        [SerializeField] private GraphGenerator _graphGenerator;
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private CellFiller _cellFiller;

        [SerializeField] private TurnSystem _turnSystem;

        [SerializeField] private TransformSelecting _everythingSelecting;

        private List<PathNode> _currentIterationNodes;
        private List<PathNode> _nextIterationNodes;
        private List<PathNode> _possibleNodes;

        private Action _turnChangedHandler;

        private int _maxDepth;
        private int _currentDepth = 0;

        private void Awake()
        {
            _turnChangedHandler += () =>
            {
                if (_turnSystem.IsPlayerTurn)
                {
                    Show(_turnSystem.ActiveUnit.transform.position, _turnSystem.ActiveUnit.Movement.Value);
                    return;
                }
                ClearLastVisualize();
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

        public void Show(Vector3 startPosition, int depth)
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
            _cellFiller.SetColors(pathNodes.Select(x => x.Coordinates).ToList(), GameColors.Movement);
        }

        public void ClearLastVisualize()
        {
            _cellFiller.SetColors(_possibleNodes?.Select(x => x.Coordinates).ToList(), GameColors.Clear);
        }

    }
}
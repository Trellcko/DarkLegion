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
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private CellFiller _cellFiller;

        [SerializeField] private Pathfinder _pathfinder;

        [SerializeField] private GameColors _gameColors;

        private List<Vector3Int> _lastVisualizeNodes;
        public void Show(Vector3 startPosition, int depth)
        {
            ClearLastVisualize();
            _pathfinder.GetAllPosiblePosition(startPosition, depth);
            _lastVisualizeNodes = _pathfinder.GetAllPosiblePosition(startPosition, depth).Select(x => _gridHandler.GetCell(x)).ToList();
            Visualize(_lastVisualizeNodes);
        }

   

        private void Visualize(List<Vector3Int> pathNodes)
        {
            _cellFiller.SetColors(pathNodes, _gameColors.Movement);
        }

        public void ClearLastVisualize()
        {
            _cellFiller.SetColors(_lastVisualizeNodes, _gameColors.Clear);
        }

    }
}
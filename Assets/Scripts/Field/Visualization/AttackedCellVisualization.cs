using DarkLegion.Core.Visualization;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class AttackedCellVisualization : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private CellFiller _cellFiller;

        private List<Vector3Int> _lastCells = new List<Vector3Int>();

        public void Show(List<Transform> points)
        {
            List<Vector3Int> attackCells = new List<Vector3Int>();

            foreach(var point in points)
            {
                attackCells.Add(_gridHandler.GetCell(point.position));
            }
            _lastCells = attackCells;
            _cellFiller.SetColors(attackCells, GameColors.Attack);
        }

        public void Clear()
        {
            _cellFiller.SetLastColors();
        }
    }
}
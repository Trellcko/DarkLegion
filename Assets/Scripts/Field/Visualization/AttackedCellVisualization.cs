using DarkLegion.Core.Visualization;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Field.Visuzalization
{
    public class AttackedCellVisualization : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private CellFiller _cellFiller;

        private List<Vector3Int> _previousAttackedCell = new List<Vector3Int>();

        public void Show(List<Transform> points)
        {
            _previousAttackedCell.Clear();

            foreach(var point in points)
            {
                _previousAttackedCell.Add(_gridHandler.GetCell(point.position));
            }
            _cellFiller.SetColors(_previousAttackedCell, GameColors.Attack);
        }

        public void ReturnPreviousColors()
        {
            _cellFiller.ReturnPreviousColors();
        }

        public void Clear()
        {
            _cellFiller.SetColors(_previousAttackedCell, GameColors.Clear);
        }
    }
}
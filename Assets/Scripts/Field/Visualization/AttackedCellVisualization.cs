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

        public void Show(Vector3 from, List<Vector3> coordinates)
        {
            List<Vector2> points = new List<Vector2>();
            
            foreach(var coordinate in coordinates)
            {
                points.Add(_gridHandler.Centralize(from) + new Vector3(coordinate.x * _gridHandler.CellSize.x, coordinate.y * _gridHandler.CellSize.y, 0));
            }
            Show(points);
        }

        public void Show(List<Vector2> points)
        {
            _previousAttackedCell.Clear();

            foreach(var point in points)
            {
                _previousAttackedCell.Add(_gridHandler.GetCell(point));
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
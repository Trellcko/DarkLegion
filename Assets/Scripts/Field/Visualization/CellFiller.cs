using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Visuzalization
{
    public class CellFiller : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;

        private Dictionary<Vector3Int, Color> _lastCellColors = new Dictionary<Vector3Int, Color>();
        public void SetColors(List<Vector3Int> cells, Color color)
        {
            _lastCellColors = new Dictionary<Vector3Int, Color>();
            cells?.ForEach(cell =>
            {
                _lastCellColors.Add(cell, _tilemap.GetColor(cell));
                _tilemap.SetColor(cell, color);
            });
        }

        public void ReturnPreviousColors()
        {
            foreach(var pair in _lastCellColors)
            {
                _tilemap.SetColor(pair.Key, pair.Value);
            }
        }

    }
}
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Local 
{
    public class LocalFieldGenerator : MonoBehaviour
    {
        [SerializeField] private Tile _baseTile;
        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private Transform _startPoint;

        [SerializeField] private Vector2Int _size;

        private Vector3Int _initialCell;

        private void Start()
        {
            _initialCell = _tilemap.WorldToCell(_startPoint.position);
            Generate(_initialCell);
        }

        private void Generate(Vector3Int from)
        {
            for (int x = 0; x < _size.x; x++)
            {
                for(int  y = 0; y < _size.y; y++)
                {
                    _tilemap.SetTile(from + new Vector3Int(x, y, 0), _baseTile);
                }
            }
        }
    }
}
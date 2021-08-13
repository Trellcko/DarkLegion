using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Visuzalization
{
    public class Visualizer : MonoBehaviour
    {
        [SerializeField] private Tile _baseTile;
        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private FieldInfo _fieldInfo;
        private void Start()
        {
            Visualize(_fieldInfo.InitCell);
        }

        private void Visualize(Vector3Int from)
        {
            for (int x = 0; x < _fieldInfo.Size.x; x++)
            {
                for (int y = 0; y < _fieldInfo.Size.y; y++)
                {
                    Vector3Int cell = from + new Vector3Int(x, y, 0);
                    _tilemap.SetTile(cell, _baseTile);
                    _tilemap.SetTileFlags(cell, TileFlags.None);
                }
            }
        }
    }
}
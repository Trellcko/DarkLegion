using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Visuzalization
{
    public class FieldVisualization : MonoBehaviour
    {
        [SerializeField] private Tile _baseTile;
        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private FieldInfo _fieldInfo;

        public void Visualize(List<Tile> tiles)
        {
            int tileIndex = 0;
            for (int x = 0; x < _fieldInfo.Size.x; x++)
            {
                for (int y = 0; y < _fieldInfo.Size.y; y++)
                {
                    Vector3Int cell = _fieldInfo.InitCell + new Vector3Int(x, y, 0);
                    _tilemap.SetTile(cell, tiles[tileIndex]);
                    _tilemap.SetTileFlags(cell, TileFlags.None);
                    tileIndex++;
                }
            }
        }
    }
}
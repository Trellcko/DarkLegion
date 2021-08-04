using DarkLegion.Field.Pathfinding;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Local
{
    public class LocalFieldGenerator : MonoBehaviour, IField
    {
        [SerializeField] private Tile _baseTile;
        [SerializeField] private Tilemap _tilemap;

        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private Transform _startPoint;

        [SerializeField] private Vector2Int _size;

        [SerializeField] private LayerMask _layers;

        public Graph Graph { get; private set; }

        private Vector3Int _initialCell;

        private void Awake()
        {
            _initialCell = _tilemap.WorldToCell(_startPoint.position);
            Generate(_initialCell);
        }

        public Graph GetGraph() => Graph;

        private void Generate(Vector3Int from)
        {
            var field = new Dictionary<Vector3Int, PathNode>();
            
            for (int x = 0; x < _size.x; x++)
            {
                for(int  y = 0; y < _size.y; y++)
                {
                    Vector3Int cell = from + new Vector3Int(x, y, 0);
                    Visualize(cell);

                    field.Add(cell, CreateNode(cell));
                }
            }
            Graph = new Graph(field);
        }

        private PathNode CreateNode(Vector3Int cell)
        {
            var pathNode = new PathNode(cell);
            pathNode.IsFree = _gridHandler.CheckForFreeSpace(cell, _layers);
            return pathNode;
        }

        private void Visualize(Vector3Int cell)
        {
            _tilemap.SetTile(cell, _baseTile);
        }
    }
}
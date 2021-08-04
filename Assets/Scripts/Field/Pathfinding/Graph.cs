using System.Collections.Generic;
using System.Linq;


using UnityEngine;

namespace PathFinding
{
    public class Graph
    {
        public int Count => _field.Count;

        private Dictionary<Vector3Int, PathNode> _field;

        private readonly Vector3Int[] neigborsCells = new Vector3Int[]
    {
                Vector3Int.up + Vector3Int.left, Vector3Int.up, Vector3Int.up + Vector3Int.right,
                Vector3Int.right, Vector3Int.left,
                Vector3Int.down + Vector3Int.left, Vector3Int.down, Vector3Int.down + Vector3Int.right
    };
        public Graph(Vector3Int initialCell, Vector2Int size)
        {
            _field = new Dictionary<Vector3Int, PathNode>();

            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    Vector3Int cell = initialCell + new Vector3Int(i, j, 0);

                    var pathNode = new PathNode(cell.x, cell.y, new List<PathNode>(), true);
                    _field.Add(cell, pathNode);

                }
            }

            List<PathNode> pathnodes = _field.Values.ToList();

            for (int i = 0; i < pathnodes.Count; i++)
            {
                for (int j = 0; j < neigborsCells.Length; j++)
                {
                    Vector3Int cell = neigborsCells[j] + new Vector3Int(pathnodes[i].X, pathnodes[i].Y, 0);
                    if (_field.ContainsKey(cell))
                    {
                        var neighborPathnode = _field[cell];

                        pathnodes[i].Neighbors.Add(neighborPathnode);
                    }
                }
            }
        }

        public PathNode GetPathNode(Vector3Int cell)
        {
            if (_field.ContainsKey(cell))
            {
                return _field[cell];
            }
            return null;

        }
    }
}
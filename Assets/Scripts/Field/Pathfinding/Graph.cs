using System.Collections.Generic;
using System.Linq;


using UnityEngine;

namespace DarkLegion.Core.Pathfinding
{
    public class Graph
    {
        public int Count => _field.Count;

        private Dictionary<Vector3Int, PathNode> _field;

        private readonly Vector3Int[] neigborsCellsForPaired = new Vector3Int[]
    {
                Vector3Int.up + Vector3Int.left, Vector3Int.up,
                Vector3Int.right, Vector3Int.left,
                Vector3Int.down + Vector3Int.left, Vector3Int.down,
    };

        private readonly Vector3Int[] neigborsCellsForOdd = new Vector3Int[]
    {
                Vector3Int.up + Vector3Int.right, Vector3Int.up,
                Vector3Int.right, Vector3Int.left,
                Vector3Int.down + Vector3Int.right, Vector3Int.down,
    };
        public Graph(Dictionary<Vector3Int, PathNode> field)
        {
            _field = field;

            List<PathNode> pathnodes = _field.Values.ToList();

            for (int i = 0; i < pathnodes.Count; i++)
            {
                var neighborsCells = pathnodes[i].Coordinates.y % 2 == 0 ? neigborsCellsForPaired : neigborsCellsForOdd;

                for (int j = 0; j < neighborsCells.Length; j++)
                {
                    Vector3Int cell = neighborsCells[j] + pathnodes[i].Coordinates;
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
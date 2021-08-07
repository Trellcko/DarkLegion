using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Utils.Pathfinding
{
    public class PathNode
    {
        public bool IsFree { get; set; }

        public Vector3Int Coordinates { get; private set; }

        public List<PathNode> Neighbors { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public PathNode CameFrom { get; set; }

        public PathNode(Vector3Int coordinates, List<PathNode> neighbors, bool isFree)
        {
            Coordinates = coordinates;
            IsFree = isFree;
            Neighbors = neighbors;
        }

        public PathNode(Vector3Int coordinates, List<PathNode> neighbors)
        {
            Coordinates = coordinates;
            IsFree = true;
            Neighbors = neighbors;
        }

        public PathNode(Vector3Int coordinates)
        {
            Coordinates = coordinates;
            IsFree = true;
            Neighbors = new List<PathNode>();
        }
    }
}
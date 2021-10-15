using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field.Pathfinding
{
    public enum PathNodeMovementCost { Easy = 5, Medium = 10, Difficult = 15, Immposible = 1000000 }

    public class PathNode
    {
        public bool IsFree { get; set; }

        public Vector3Int Coordinates { get; private set; }

        public List<PathNode> Neighbors { get; set; }

        public PathNodeMovementCost MovementCost { get; } = PathNodeMovementCost.Easy;

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public PathNode CameFrom { get; set; }

        public PathNode(Vector3Int coordinates, PathNodeMovementCost movementCost, List<PathNode> neighbors, bool isFree)
        {
            Coordinates = coordinates;
            IsFree = isFree;
            Neighbors = neighbors;
            MovementCost = movementCost;
        }

        public PathNode(Vector3Int coordinates, PathNodeMovementCost movementCost, List<PathNode> neighbors)
        {
            Coordinates = coordinates;
            IsFree = true;
            Neighbors = neighbors;
            MovementCost = movementCost;
        }

        public PathNode(Vector3Int coordinates, PathNodeMovementCost movementCost)
        {
            Coordinates = coordinates;
            IsFree = true;
            Neighbors = new List<PathNode>();
            MovementCost = movementCost;
        }
    }
}
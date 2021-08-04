using System.Collections.Generic;

namespace PathFinding
{
    public class PathNode
    {
        public bool IsFree { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public List<PathNode> Neighbors { get; set; }

        public int GCost { get; set; }
        public int HCost { get; set; }
        public int FCost => GCost + HCost;

        public PathNode CameFrom { get; set; }

        public PathNode(int x, int y, List<PathNode> neighbors, bool isFree)
        {
            X = x;
            Y = y;
            IsFree = isFree;
            Neighbors = neighbors;
        }

        public PathNode(int x, int y, List<PathNode> neighbors)
        {
            X = x;
            Y = y;
            IsFree = true;
            Neighbors = neighbors;
        }

    }
}
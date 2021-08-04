using System;
using System.Collections.Generic;

namespace PathFinding
{
    public class AStar
    {
        private const int STRAIGTH_MOVE_COST = 10;
        private const int DIAGONAL_MOVE_COST = 14;

        private List<PathNode> _openList;
        private List<PathNode> _closeList;
        private Graph _graph;

        public AStar(Graph graph)
        {
            _graph = graph;
        }

        public List<PathNode> FindPath(PathNode startNode, PathNode targetNode)
        {
            if (targetNode.IsFree == false)
            {
                return new List<PathNode>();
            }
            if (startNode == targetNode)
            {
                return new List<PathNode>() { targetNode };
            }
            _closeList = new List<PathNode>();
            _openList = new List<PathNode>() { startNode };
            SetDataForPathNode(targetNode, null, startNode, 0);

            while (_openList.Count > 0)
            {

                PathNode currentNode = GetLowerFCostPathNode(_openList);

                if (currentNode == targetNode)
                {
                    return MakePath(targetNode);
                }
                _openList.Remove(currentNode);
                _closeList.Add(currentNode);

                List<PathNode> neighbourNodes = currentNode.Neighbors;
                for (int i = 0; i < neighbourNodes.Count; i++)
                {
                    if (_closeList.Contains(neighbourNodes[i]))
                    {
                        continue;
                    }
                    if (neighbourNodes[i].IsFree == false)
                    {

                        _closeList.Add(neighbourNodes[i]);
                        continue;
                    }
                    int tentativeCost = currentNode.GCost + CalculatDistance(currentNode, neighbourNodes[i]);
                    SetDataForPathNode(targetNode, currentNode, neighbourNodes[i], tentativeCost);
                    if (!_openList.Contains(neighbourNodes[i]))
                    {
                        _openList.Add(neighbourNodes[i]);
                    }


                }
            }
            return new List<PathNode>();

        }

        private void SetDataForPathNode(PathNode targetNode, PathNode cameFrom, PathNode currentNode, int gCost)
        {
            currentNode.CameFrom = cameFrom;
            currentNode.GCost = gCost;
            currentNode.HCost = CalculatDistance(currentNode, targetNode);
        }

        private List<PathNode> MakePath(PathNode endPathNode)
        {
            List<PathNode> path = new List<PathNode>();
            PathNode currenPathNode = endPathNode;
            while (currenPathNode.CameFrom != null)
            {
                path.Add(currenPathNode);
                currenPathNode = currenPathNode.CameFrom;
            }
            path.Reverse();
            return path;
        }

        private PathNode GetLowerFCostPathNode(List<PathNode> pathNodes)
        {
            PathNode lowerFCostPathNode = pathNodes[0];
            for (int i = 1; i < pathNodes.Count; i++)
            {
                if (lowerFCostPathNode.FCost > pathNodes[i].FCost)
                {
                    lowerFCostPathNode = pathNodes[i];
                }
            }
            return lowerFCostPathNode;

        }

        private int CalculatDistance(PathNode a, PathNode b)
        {
            int xDistance = Math.Abs(a.X - b.X);
            int yDistance = Math.Abs(a.Y - b.Y);
            int remaining = Math.Abs(xDistance - yDistance);

            return DIAGONAL_MOVE_COST * Math.Min(xDistance, yDistance) + STRAIGTH_MOVE_COST * remaining;
        }

    }
}
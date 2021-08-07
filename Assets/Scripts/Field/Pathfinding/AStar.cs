using System;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Utils.Pathfinding
{
    public class AStar
    {

        private List<PathNode> _openList;
        private List<PathNode> _closeList;

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

                PathNode currentNode = GetLowerFCostPathNode(_openList, targetNode);

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
            while (currenPathNode != null)
            {
                path.Add(currenPathNode);
                currenPathNode = currenPathNode.CameFrom;
            }
            path.Reverse();
            return path;
        }

        private PathNode GetLowerFCostPathNode(List<PathNode> pathNodes, PathNode targetNode)
        {
            PathNode lowerFCostPathNode = pathNodes[0];
            for (int i = 1; i < pathNodes.Count; i++)
            {
                if (lowerFCostPathNode.FCost == pathNodes[i].FCost)
                {

                    if (CalculateSumOfDifferenceCoordinates(lowerFCostPathNode, targetNode) >
                        CalculateSumOfDifferenceCoordinates(pathNodes[i], targetNode))
                    {
                        lowerFCostPathNode = pathNodes[i];
                    }
                }
                else if (lowerFCostPathNode.FCost > pathNodes[i].FCost)
                {
                    lowerFCostPathNode = pathNodes[i];
                }
            }
            return lowerFCostPathNode;

        }

        private int CalculateSumOfDifferenceCoordinates(PathNode a, PathNode b)
        {
            Vector3Int difference = b.Coordinates - a.Coordinates;
            return Mathf.Abs(difference.x) + Mathf.Abs(difference.y);
        }

        private int CalculatDistance(PathNode a, PathNode b)
        {
            int xDistance = Math.Abs(a.Coordinates.x - b.Coordinates.x);
            int yDistance = Math.Abs(a.Coordinates.y - b.Coordinates.y);
            int remaining = Math.Abs(xDistance - yDistance);

            return Math.Min(xDistance, yDistance) + remaining;
        }

    }
}
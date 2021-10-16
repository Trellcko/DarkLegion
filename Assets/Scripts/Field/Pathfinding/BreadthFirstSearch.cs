using System.Collections.Generic;
using UnityEngine.Assertions;

namespace DarkLegion.Field.Pathfinding
{
    public class BreadthFirstSearch
    {
        public List<PathNode> FindPath(PathNode startNode, PathNode endNode, int movementPoints)
        {
            List<PathNode> visitedNodes = GetAllPossibleNodes(startNode, movementPoints);
            
            List<PathNode> path = new List<PathNode>();

            if (visitedNodes.Contains(endNode))
            {
                PathNode currentNode = endNode;
                path.Add(currentNode);
                
                while(currentNode.CameFrom != null)
                {
                    path.Add(currentNode.CameFrom);
                    currentNode = currentNode.CameFrom;
                }
                path.Reverse();
            }

            return path;
        }

        public List<PathNode> GetAllPossibleNodes(PathNode startNode, int movementPoints)
        {
            List<PathNode> visitedNodes = new List<PathNode>();
            Dictionary<PathNode, int> costSoFar = new Dictionary<PathNode, int>();
            Queue<PathNode> needsToVisit = new Queue<PathNode>();

            startNode.CameFrom = null;
            visitedNodes.Add(startNode);

            needsToVisit.Enqueue(startNode);
            costSoFar.Add(startNode, 0);

            while(needsToVisit.Count > 0)
            {
                PathNode currentNode = needsToVisit.Dequeue();
                foreach(var neighborNode in currentNode.Neighbors)
                {
                    if(neighborNode.IsFree == false && neighborNode.MovementCost == PathNodeMovementCost.Immposible)
                    {
                        continue;

                    }

                    int nodecost = (int)neighborNode.MovementCost;
                    int currentcost = costSoFar[currentNode];
                    int newCost = nodecost + currentcost;
                    if(newCost <= movementPoints)
                    {
                        if(visitedNodes.Contains(neighborNode) == false)
                        {
                            visitedNodes.Add(neighborNode);
                            neighborNode.CameFrom = currentNode;
                            costSoFar.Add(neighborNode, newCost);
                            needsToVisit.Enqueue(neighborNode);
                        }
                        else if(costSoFar[neighborNode] > newCost)
                        {
                            costSoFar[neighborNode] = newCost;
                            neighborNode.CameFrom = currentNode;
                        }
                    }
                }
            }
            return visitedNodes;
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Field.Pathfinding
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;

        [SerializeField] private GameObject _fieldGO;

        private IField _field;

        private AStar _aStar;

        private void Awake()
        {
            _field = _fieldGO.GetComponent<IField>();
            _aStar = new AStar();
        }

        public List<Vector3> FindPath(Vector2 startPosition, Vector2 targetPosition)
        {
            PathNode startNode = GetNode(startPosition);
            PathNode targetNode = GetNode(targetPosition);
            if (startNode == null || targetNode == null)
            {
                return new List<Vector3>();
            }
            return ConvertPathNodeToVector3(_aStar.FindPath(startNode, targetNode));

        }

        public List<Vector3> ConvertPathNodeToVector3(List<PathNode> pathNodes)
        {
            if (pathNodes.Count == 0) return new List<Vector3>();
            List<Vector3> result = new List<Vector3>();
            for (int i = 0; i < pathNodes.Count; i++)
            {
                result.Add(_gridHandler.GetWorldCenterPosition(pathNodes[i].Coordinates));
            }
            return result;
        }

        private PathNode GetNode(Vector2 startPosition)
        {
            return _field.GetGraph().GetPathNode(_gridHandler.GetCell(startPosition));
        }
    }
}

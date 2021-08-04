using System.Collections.Generic;
using UnityEngine;

namespace PathFinding
{
    public class PathFinder : MonoBehaviour
    {
        [SerializeField] private Grid _grid;
        [SerializeField] private LayerMask _layers;

        [SerializeField] private Transform _startPoint;
        [SerializeField] private Vector2Int _size;

        public Graph Graph { get; private set; }

        public Vector2 CellSize => _grid.cellSize;



        private AStar _aStar;

        private Vector3Int _initialCell = Vector3Int.zero;

        private void Awake()
        {
            _initialCell = GetCell(_startPoint.position);
            Graph = new Graph(_initialCell, _size);
            _aStar = new AStar(Graph);
            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                {
                    Vector3Int cell = new Vector3Int(i, j, 0) + _initialCell;
                    Graph.GetPathNode(cell).IsFree = CheckForFreeSpace(cell);
                }
            }
        }



        public List<Vector2> FindPath(Vector2 startPosition, Vector2 targetPosition)
        {
            PathNode startNode = GetNode(startPosition);
            PathNode targetNode = GetNode(targetPosition);
            if (startNode == null || targetNode == null)
            {
                return new List<Vector2>();
            }
            return ConvertPathNodeToVector2(_aStar.FindPath(startNode, targetNode));

        }

        public List<Vector2> ConvertPathNodeToVector2(List<PathNode> pathNodes)
        {
            if (pathNodes.Count == 0) return new List<Vector2>();
            List<Vector2> result = new List<Vector2>();
            for (int i = 0; i < pathNodes.Count; i++)
            {
                result.Add(GetWorldCenterPosition(pathNodes[i]));
            }
            return result;
        }


        public bool CheckForFreeSpace(Vector3Int cell)
        {
            return Physics2D.OverlapCircleNonAlloc(GetWorldCenterPosition(cell), (CellSize.x / 2) - 0.05f, new Collider2D[1], _layers) == 0;
        }

        public Vector3 GetWorldCenterPosition(Vector3Int cell)
        {
            return _grid.GetCellCenterWorld(cell);
        }

        public Vector3 GetWorldPosition(Vector3Int cell)
        {
            return _grid.CellToWorld(cell);
        }

        public Vector3 GetWorldPosition(PathNode pathNode)
        {
            return GetWorldPosition(new Vector3Int(pathNode.X, pathNode.Y, 0));
        }

        private Vector3Int GetCell(Vector3 worldPosition)
        {
            return _grid.WorldToCell(worldPosition);
        }

        public Vector3 GetWorldCenterPosition(PathNode pathNode)
        {
            return GetWorldCenterPosition(new Vector3Int(pathNode.X, pathNode.Y, 0));
        }

        public PathNode GetNode(Vector3 worldPosition)
        {
            Vector3Int cell = _grid.WorldToCell(worldPosition);
            return Graph.GetPathNode(cell);
        }

        public void DrawGrid()
        {
            for (int i = 0; i < _size.x; i++)
            {
                for (int j = 0; j < _size.y; j++)
                {
                    Vector2 from = (Vector2)GetWorldPosition(new Vector3Int(i + _initialCell.x, j + _initialCell.y, 0));
                    Vector2 to = from + new Vector2(CellSize.x, 0);
                    Debug.DrawLine(to, from, Color.red, 100);
                    to = from + new Vector2(0, CellSize.y);
                    Debug.DrawLine(to, from, Color.red, 100);
                }
            }
            Vector2 finishVerticalLineStart = GetWorldPosition(new Vector3Int(_size.x + _initialCell.x, _initialCell.y, 0));
            Vector2 finishPoint = GetWorldPosition(new Vector3Int(_size.x + _initialCell.x, _size.y + _initialCell.y, 0));
            Debug.DrawLine(finishVerticalLineStart, finishPoint, Color.red, 100);


            Vector2 finishHorizontalLineStart = GetWorldCenterPosition(new Vector3Int(_initialCell.x, _size.y + _initialCell.y, 0));
            Debug.DrawLine(finishHorizontalLineStart, finishHorizontalLineStart, Color.red, 100);
        }

    }
}

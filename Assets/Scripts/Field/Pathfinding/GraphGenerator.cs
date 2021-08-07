using DarkLegion.Utils.Pathfinding;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Utils
{
    public class GraphGenerator : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private FieldInfo _fieldInfo;

        public Graph Graph { get; private set; }

        private void Awake()
        {
            var initialCell = _gridHandler.GetCell(_fieldInfo.StartPoint.position);
            initialCell.z = 0;
            Generate(initialCell);
        }

        private void Generate(Vector3Int from)
        {
            var field = new Dictionary<Vector3Int, PathNode>();
            
            for (int x = 0; x < _fieldInfo.Size.x; x++)
            {
                for(int  y = 0; y < _fieldInfo.Size.y; y++)
                {
                    Vector3Int cell = from + new Vector3Int(x, y, 0);;
                    field.Add(cell, CreateNode(cell));
                }
            }
            Graph = new Graph(field);
        }

        private PathNode CreateNode(Vector3Int cell)
        {
            var pathNode = new PathNode(cell);
            pathNode.IsFree = _gridHandler.CheckForFreeSpace(cell, _fieldInfo.FieldsLayers);
            return pathNode;
        }
    }
}
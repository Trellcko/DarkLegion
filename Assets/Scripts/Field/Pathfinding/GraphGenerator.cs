using DarkLegion.Field.Pathfinding;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Field
{
    public class GraphGenerator : MonoBehaviour
    {
        [SerializeField] private GridHandler _gridHandler;
        [SerializeField] private FieldInfo _fieldInfo;

        public Graph Graph { get; private set; }

        public void Generate(Vector3Int from, Dictionary<Vector2Int, PathNodeMovementCost> movementCosts)
        {
            var field = new Dictionary<Vector3Int, PathNode>();
            
            for (int x = 0; x < _fieldInfo.Size.x; x++)
            {
                for(int  y = 0; y < _fieldInfo.Size.y; y++)
                {
                    Vector3Int tempCoordinates = new Vector3Int(x, y, 0);
                    Vector3Int cell = from + tempCoordinates;
                    field.Add(cell, CreateNode(cell, movementCosts[(Vector2Int)tempCoordinates]));
                }
            }
            Graph = new Graph(field);
        }

        private PathNode CreateNode(Vector3Int cell, PathNodeMovementCost movementCost)
        {
            var pathNode = new PathNode(cell, movementCost)
            {
                IsFree = _gridHandler.CheckForFreeSpace(cell, _fieldInfo.FieldsLayers)
            };
            return pathNode;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DarkLegion.Field.Visuzalization;
using UnityEngine.Tilemaps;
using DarkLegion.Field.Pathfinding;

namespace DarkLegion.Field.Generation
{
    public class PerlinNoiseFieldGenerator : MonoBehaviour
    {
        [SerializeField] private FieldVisualization _fieldVisualization;
        [SerializeField] private GraphGenerator _graphGenerator; 
        [SerializeField] private FieldInfo _fieldInfo;
        [SerializeField] private GenerationData _generationData;

        [SerializeField] private float _perlinNoiseScale = 20f;

        private Dictionary<float, TileData> _tilesValues;

        private int _randomOffsetX;
        private int _randomOffsetY;

        private void Start()
        {
            _randomOffsetX = Random.Range(0, 99999);
            _randomOffsetY = Random.Range(0, 99999);
            _tilesValues = _generationData.TilesValue.OrderBy(x => x.Key).ToDictionary(y=> y.Key, j => j.Value);
            Generate();
        }

        public void Generate()
        {
            List<Tile> tiles = new List<Tile>();
            Dictionary<Vector2Int, PathNodeMovementCost> pathNodeMovementCosts = new Dictionary<Vector2Int, PathNodeMovementCost>();

            for(int  i = 0; i < _fieldInfo.Size.x; i++)
            {
                for (int j = 0; j < _fieldInfo.Size.y; j++)
                {
                    TileData tileData = GetTileDataByPerlinNoiseValue(CalculatePerlinNoiseValue(i, j));
                    tiles.Add(tileData.Tile);
                    pathNodeMovementCosts.Add(new Vector2Int(i,j), tileData.PathNodeMovementCost);
                }
            }
            _graphGenerator.Generate(_fieldInfo.InitCell, pathNodeMovementCosts);
            _fieldVisualization.Visualize(tiles);
        }

        private float CalculatePerlinNoiseValue(int x, int y)
        {
            float perlinX = (float)x / _fieldInfo.Size.x * _perlinNoiseScale + _randomOffsetX;
            float perlinY = (float)y / _fieldInfo.Size.y * _perlinNoiseScale + _randomOffsetY;
            return Mathf.PerlinNoise(perlinX, perlinY);
        }

        private TileData GetTileDataByPerlinNoiseValue(float value)
        {
            foreach (var tileValuePair in _tilesValues)
            {
                if (tileValuePair.Key >= value)
                    return tileValuePair.Value;
            }
            Debug.LogError("Wrong GenerationData");
            return null;
        }

    }
}

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DarkLegion.Field.Visuzalization;
using UnityEngine.Tilemaps;



namespace DarkLegion.Field.Generation
{
    public class Generator : MonoBehaviour
    {
        [SerializeField] private FieldVisualization _fieldVisualization;
        [SerializeField] private FieldInfo _fieldInfo;
        [SerializeField] private GenerationData _generationData;

        [SerializeField] private float _perlinNoiseScale = 20f;

        private Dictionary<float, Tile> _tilesValues;

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

            for(int  i = 0; i < _fieldInfo.Size.x; i++)
            {
                for (int j = 0; j < _fieldInfo.Size.y; j++)
                {
                    tiles.Add(GetTileByPerlinNoiseValue(CalculatePerlinNoiseValue(i, j)));
                }
            }

            _fieldVisualization.Visualize(tiles);
        }

        private float CalculatePerlinNoiseValue(int x, int y)
        {
            float perlinX = (float)x / _fieldInfo.Size.x * _perlinNoiseScale + _randomOffsetX;
            float perlinY = (float)y / _fieldInfo.Size.y * _perlinNoiseScale + _randomOffsetY;
            return Mathf.PerlinNoise(perlinX, perlinY);
        }

        private Tile GetTileByPerlinNoiseValue(float value)
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

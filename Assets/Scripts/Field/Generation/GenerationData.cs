using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Generation
{
    [ShowOdinSerializedPropertiesInInspector]
    [CreateAssetMenu(fileName = "New GenerationData", menuName = "Field/Generation/GenerationData", order = 41)]
    public class GenerationData : SerializedScriptableObject
    {
        [field: SerializeField] public Dictionary<float, TileData> TilesValue { get; private set; }
    }
}
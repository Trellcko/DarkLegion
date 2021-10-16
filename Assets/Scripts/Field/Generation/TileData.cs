using DarkLegion.Field.Pathfinding;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DarkLegion.Field.Generation
{
    [CreateAssetMenu(fileName = "new TileData", menuName = "Field/Generation/TileData", order = 41)]
    public class TileData : ScriptableObject
    {
        [field: SerializeField] public Tile Tile { get; private set; }
        [field: SerializeField] public PathNodeMovementCost PathNodeMovementCost { get; private set; }
    }
}
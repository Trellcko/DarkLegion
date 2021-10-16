using UnityEngine;

namespace DarkLegion.Core.Visualization
{
    [CreateAssetMenu(fileName = "new GameColors", menuName = "Core/Visualization/GameColors", order = 41)]
    public class GameColors : ScriptableObject
    {
        [field: SerializeField] public Color Movement { get; private set; }
        [field: SerializeField] public Color Attack { get; private set; }
        [field: SerializeField] public Color Clear { get; private set; }
        [field: SerializeField] public Color Buff { get; private set; }
        [field: SerializeField] public Color DeBuff { get; private set; }
    }
}
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem.Visualization
{
    [CreateAssetMenu(fileName = "new BuffMaterialsData", menuName = "Unit/AttackSystem/Visualization/BuffMaterialsData", order = 41)]

    public class BuffMaterialsData : ScriptableObject
    {
        [field: SerializeField] public Material PositiveBuff { get; private set; }

        [field: SerializeField] public Material NegativeBuff { get; private set; }
    }
}
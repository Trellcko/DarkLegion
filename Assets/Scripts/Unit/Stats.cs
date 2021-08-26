using UnityEngine;
namespace DarkLegion.Unit
{
    [CreateAssetMenu(fileName = "New UnitStat", menuName = "Units/Stat", order = 41)]
    public class Stats : ScriptableObject
    {
        [field: SerializeField] public int MaxStep { get; private set; }

        [field: SerializeField, Range(0f, 1000f)] public float Health { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float PhysicalDamage { get; private set; }
    }
}
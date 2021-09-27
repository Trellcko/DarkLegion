using UnityEngine;

namespace DarkLegion.Unit.Stat
{
    [CreateAssetMenu(fileName = "New UnitBaseInfo", menuName = "Units/BaseInfo", order = 41)]
    public class BaseInfo : ScriptableObject
    {
        [field: SerializeField] public int Movement { get; private set; }

        [field: SerializeField, Range(0f, 1000f)] public float Health { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float PhysicalDamage { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float PhysicalDefense { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float MagicAttack { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public float MagicDefense { get; private set; }

        [field: SerializeField, Range(0, 10f)] public int Reaction { get; private set; }

        [field: SerializeField, Range(0, 5)] public int ActivePointsCount { get; private set; }

        [field: SerializeField] public Sprite TurnIcon { get; private set; }

        [field: SerializeField] public string Name { get; private set; }
    }
}
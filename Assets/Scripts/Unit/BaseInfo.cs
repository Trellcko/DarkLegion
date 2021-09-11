using UnityEngine;

namespace DarkLegion.Unit.Stat
{
    [CreateAssetMenu(fileName = "New UnitBaseInfo", menuName = "Units/BaseInfo", order = 41)]
    public class BaseInfo : ScriptableObject
    {
        [field: SerializeField] public int MaxStep { get; private set; }

        [field: SerializeField, Range(0f, 1000f)] public int Health { get; private set; }

        [field: SerializeField, Range(0f, 100f)] public int PhysicalDamage { get; private set; }

        [field: SerializeField, Range(0, 10f)] public int Initiative { get; private set; }

        [field: SerializeField, Range(0, 5)] public int AttackPointsCount { get; private set; }

        [field: SerializeField] public Sprite TurnIcon { get; private set; }
    }
}
using DarkLegion.Core.Command;
using DarkLegion.Unit.AttackSystem;

using UnityEngine;

namespace DarkLegion.Unit
{
    public class ComponentStorage : MonoBehaviour
    {
        [field: SerializeField] public CommandHandler CommandHandler { get; private set; }

        [field: SerializeField] public Health Health { get; private set; }

        [field: SerializeField] public AnimatorHandler Animator { get; private set; }

        [field: SerializeField] public Stats BaseStats { get; private set; }
        
        [field: SerializeField] public SkillSet UnitSkillSet { get; private set; }
}
}
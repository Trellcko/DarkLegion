using DarkLegion.Core.Command;
using DarkLegion.Unit.AttackSystem;

using UnityEngine;

namespace DarkLegion.Unit
{
    public class ComponentStorage : MonoBehaviour
    {
        [field: SerializeField] public CommandHandler CommandHandler { get; private set; }

        [field: SerializeField] public HealtHandler Health { get; private set; }

        [field: SerializeField] public AnimatorHandler Animator { get; private set; }

        [field: SerializeField] public Movement Movement { get; private set; }

        [field: SerializeField] public PhysicalDamage PhysicalDamage { get; private set; }
        
        [field: SerializeField] public SkillSet UnitSkillSet { get; private set; }
}
}
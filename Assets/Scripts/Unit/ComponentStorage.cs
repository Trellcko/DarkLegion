using DarkLegion.Core.Command;
using DarkLegion.Unit.AttackSystem;
using DarkLegion.Unit.Stat;
using UnityEngine;

namespace DarkLegion.Unit
{
    public class ComponentStorage : MonoBehaviour
    {
        [field: SerializeField] public CommandHandler CommandHandler { get; private set; }

        [field: SerializeField] public HealtHandler Health { get; private set; }

        [field: SerializeField] public AnimatorHandler Animator { get; private set; }

        [field: SerializeField] public BaseInfo BaseInfo { get; private set; }

        [field: SerializeField] public Movement Movement { get; private set; }

        [field: SerializeField] public Reaction Reaction { get; private set; }

        [field: SerializeField] public ActionPoints ActionPoints { get; private set; }

        [field: SerializeField] public PhysicalDamage PhysicalDamage { get; private set; }

        [field: SerializeField] public SkillSet SkillSet { get; private set; }

        [field: SerializeField] public BuffStorage BuffStorage { get; private set; }
    }

}
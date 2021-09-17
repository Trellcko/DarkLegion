using DarkLegion.Unit.Stat;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillEffectOfTakingDamage : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private PhysicalDamage _physicalDamage;

        public void Do(List<ComponentStorage> targets)
        {
            foreach (var target in targets)
            {
                target.Health.TakeDamage(_physicalDamage.Value);
            }
        }
    }
}
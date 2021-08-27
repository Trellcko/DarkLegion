using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class DamageEffect : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private ComponentStorage _componentStorage;
        public void Attack(List<ComponentStorage> targets)
        {

            foreach(var target in targets)
            {
                target.Health.TakeDamage(_componentStorage.BaseStats.PhysicalDamage);
            }
        }
    }
}
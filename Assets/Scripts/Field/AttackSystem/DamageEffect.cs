using DarkLegion.Unit;

using UnityEngine;

namespace DarkLegion.Field.AttackSystem
{
    public class DamageEffect : MonoBehaviour, IAttackEffect
    {
        public void Attack(ComponentStorage who, ComponentStorage whom)
        {
            Debug.Log(whom.name + " take " + who.BaseStats.PhysicalDamage + " damage");
        }
    }
}
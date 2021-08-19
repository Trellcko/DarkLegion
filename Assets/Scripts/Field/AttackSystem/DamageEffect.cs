using DarkLegion.Units;

using UnityEngine;

namespace DarkLegion.Field.AttackSystem
{
    public class DamageEffect : MonoBehaviour, IAttackEffect
    {
        public void Attack(Unit who, Unit whom)
        {
            Debug.Log(whom.name + " take " + who.UnitData.PhysicalDamage + " damage");
        }
    }
}
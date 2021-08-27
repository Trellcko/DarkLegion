using System.Collections.Generic;

namespace DarkLegion.Unit.AttackSystem
{
    public interface ISkillEffect
    {
        void Attack(List<ComponentStorage> targets);
    }
}
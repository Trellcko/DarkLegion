using System.Collections.Generic;

namespace DarkLegion.Unit.AttackSystem
{
    public interface ISkillEffect
    {
        void Do(ComponentStorage who, List<ComponentStorage> targets);
    }
}
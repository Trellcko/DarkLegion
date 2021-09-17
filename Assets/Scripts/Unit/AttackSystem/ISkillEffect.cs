using System.Collections.Generic;

namespace DarkLegion.Unit.AttackSystem
{
    public interface ISkillEffect
    {
        void Do(List<ComponentStorage> componentStorages);
    }
}
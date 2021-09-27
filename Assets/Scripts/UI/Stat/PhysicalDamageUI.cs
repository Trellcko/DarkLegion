using DarkLegion.Unit;
using DarkLegion.Unit.Stat;
using UnityEngine;

namespace DarkLegion.UI
{
    public class PhysicalDamageUI : StatUI<PhysicalDamage>
    {
        public override float GetBaseStatValue(BaseInfo baseInfo)
        {
            return baseInfo.PhysicalDamage;
        }

        public override PhysicalDamage GetNeedStat(ComponentStorage unit)
        {
            return unit.PhysicalDamage;
        }

    }
}
using DarkLegion.Unit;
using DarkLegion.Unit.Stat;

namespace DarkLegion.UI {
    public class PhysicalDefenseUI : StatUI<PhysicalDefense>
    {
        public override float GetBaseStatValue(BaseData baseInfo)
        {
            return baseInfo.PhysicalDefense;
        }

        public override PhysicalDefense GetNeedStat(ComponentStorage unit)
        {
            return unit.PhysicalDefense;
        }
    }
}
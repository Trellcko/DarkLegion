using DarkLegion.Unit;
using DarkLegion.Unit.Stat;

namespace DarkLegion.UI
{
    public class MagicDefenseUI : StatUI<MagicDefense>
    {
        public override float GetBaseStatValue(BaseInfo baseInfo)
        {
            return baseInfo.MagicDefense;
        }

        public override MagicDefense GetNeedStat(ComponentStorage unit)
        {
            return unit.MagicDefense;
        }
    }
}
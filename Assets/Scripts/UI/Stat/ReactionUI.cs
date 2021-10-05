using DarkLegion.Unit;
using DarkLegion.Unit.Stat;

namespace DarkLegion.UI
{
    public class ReactionUI : StatUI<Reaction>
    {
        public override float GetBaseStatValue(BaseData baseInfo)
        {
            return baseInfo.Reaction;
        }

        public override Reaction GetNeedStat(ComponentStorage unit)
        {
            return unit.Reaction;
        }
    }
}
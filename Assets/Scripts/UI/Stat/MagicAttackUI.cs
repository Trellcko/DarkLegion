using DarkLegion.Unit;
using DarkLegion.Unit.Stat;

namespace DarkLegion.UI
{
    public class MagicAttackUI : StatUI<MagicAttack>
    {
        public override float GetBaseStatValue(BaseInfo baseInfo)
        {
            return baseInfo.MagicAttack;
        }

        public override MagicAttack GetNeedStat(ComponentStorage unit)
        {
            return unit.MagicAttack;
        }
    }
}
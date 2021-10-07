using DarkLegion.Unit;
using DarkLegion.Unit.Stat;

namespace DarkLegion.UI
{
    public class MovementUI : StatUI<Movement>
    {
        public override float GetBaseStatValue(BaseData baseInfo)
        {
            return baseInfo.Movement;
        }

        public override Movement GetNeedStat(ComponentStorage unit)
        {
            return unit.Movement;
        }
    }
}
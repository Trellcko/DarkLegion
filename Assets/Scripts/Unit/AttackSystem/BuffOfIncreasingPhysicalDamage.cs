using DarkLegion.Unit.Stat;

namespace DarkLegion.Unit.AttackSystem
{
    public class BuffOfIncreasingPhysicalDamage : Buff<PhysicalDamage>
    {
        public BuffOfIncreasingPhysicalDamage(PhysicalDamage stat, float value, int duration,  bool isFixed = true, bool isInfinity = false) : base(stat, value, duration, true, isFixed, isInfinity)
        {
        }
    }
}
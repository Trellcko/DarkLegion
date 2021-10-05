using DarkLegion.Unit.AttackSystem;
using DarkLegion.Unit.Stat;

public class BuffOfDeacreasingPhysicalDamage : Buff<PhysicalDamage>
{
    public BuffOfDeacreasingPhysicalDamage(PhysicalDamage stat, float value, int duration, bool isFixed = true, bool isInfinity = false) : base(stat, value, duration, false, isFixed, isInfinity)
    {
    }

}

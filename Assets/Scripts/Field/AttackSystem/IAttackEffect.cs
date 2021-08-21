using DarkLegion.Units;

namespace DarkLegion.Field.AttackSystem
{
    public interface IAttackEffect
    {
        void Attack(Unit player, Unit target);
    }
}
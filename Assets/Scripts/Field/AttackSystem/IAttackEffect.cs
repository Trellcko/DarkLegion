using DarkLegion.Unit;

namespace DarkLegion.Field.AttackSystem
{
    public interface IAttackEffect
    {
        void Attack(ComponentStorage player, ComponentStorage target);
    }
}
using UnityEngine;

namespace DarkLegion.Unit.Stat
{
    public class Health : BaseStat
    {
        public override void Set(int value)
        {
            Value = Mathf.Clamp(value, 0, BaseStats.Health);
        }

        protected override void Init()
        {
            Value = BaseStats.Health;
        }
    }
}
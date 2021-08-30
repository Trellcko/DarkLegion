using UnityEngine;

namespace DarkLegion.Unit
{
    public class Health : Stat
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
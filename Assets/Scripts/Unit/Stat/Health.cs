using DarkLegion.Core;
using System;
using UnityEngine;

namespace DarkLegion.Unit.Stat
{
    public class Health : BaseStat, IValueChanged
    {
        public float GetValue()
        {
            return Value;
        }

        public override void Set(float value)
        {
             Value = Mathf.Clamp(value, 0, BaseStats.Health);
        }

        protected override void Init()
        {
            Value = BaseStats.Health;
        }
    }
}
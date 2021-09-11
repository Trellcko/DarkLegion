using System;

namespace DarkLegion.Unit.Stat
{
    public class ActionPoints : BaseStat, IDisposable
    {
        protected override void Init()
        {
            Value = BaseStats.AttackPointsCount;
        }

        public void Dispose()
        {
            Init();
        }

    }
}
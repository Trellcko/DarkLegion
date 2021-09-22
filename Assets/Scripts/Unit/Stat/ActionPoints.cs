using System;

namespace DarkLegion.Unit.Stat
{
    public class ActionPoints : BaseStat, IDisposable
    {
        public event Action Emptied;
        protected override void Init()
        {
            Value = BaseStats.ActivePointsCount;
        }

        public override void Set(float value)
        {
            if(value < 0)
            {
                value = 0;
            }
            if(value == 0)
            {
                Emptied?.Invoke();
            }
            Value = value;
            
        }

        public void Dispose()
        {
            Init();
        }

    }
}
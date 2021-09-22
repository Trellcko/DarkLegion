using DarkLegion.Unit.Stat;
using DarkLegion.Utils;
namespace DarkLegion.Unit.AttackSystem
{
    public abstract class Buff<T> : IBuff where T : BaseStat
    {
        public bool IsFixed { get; }
        public bool IsPositiveBuff { get; }
        public bool IsInfinity { get; }

        public float Value { get; }

        public bool IsBuffActionCompleted => _currentDuration <= 0;

        private T _targetStat;

        private float _increasedStatValue = 0;

        private int _currentDuration;

        private readonly int _maxDuration = 0;
        private readonly int _factor = 1;
        
        public Buff(T stat, float value, int duration, bool isPositiveBuff, bool isFixed = true, bool isInfinity = false)
        {
            _targetStat = stat;
            IsFixed = isFixed;
            IsPositiveBuff = isPositiveBuff;
            Value = value;
            _maxDuration = duration;
            _currentDuration = _maxDuration;
            _factor = isPositiveBuff ? 1 : -1;
            IsInfinity = isInfinity;
        }

        public void Do()
        {
            _increasedStatValue = IsFixed == false ? MathExtensions.CalculateValueFromPrecent(_targetStat.Value, Value) :
                 Value * _factor;
            _targetStat.Set(_targetStat.Value + _increasedStatValue);
        }

        public void DecreaseDuration()
        {
            if (IsInfinity)
            {
                return;
            }
            _currentDuration--;
        }

        public void Undo()
        {
            _targetStat.Set(_targetStat.Value - _increasedStatValue);
        }
    }
}
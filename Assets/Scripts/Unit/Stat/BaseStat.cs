using UnityEngine;

namespace DarkLegion.Unit.Stat
{
    public abstract class BaseStat : MonoBehaviour
    {
        [SerializeField] protected BaseInfo BaseStats;

        public int Value { get; protected set; }

        private void Awake()
        {
            Init();
        }

        public virtual void Set(int value)
        {
            if (value < 0)
            {
                value = 0;
            }
            Value = value;
        }

        protected abstract void Init();
    }
}
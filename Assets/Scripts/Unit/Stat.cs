using UnityEngine;

namespace DarkLegion.Unit
{
    public abstract class Stat : MonoBehaviour
    {
        [SerializeField] protected BaseStats BaseStats;
        
        public int Value { get; protected set; }

        private void Start()
        {
            Init();
        }
        
        public virtual void Set(int value)
        {
            if(value < 0)
            {
                value = 0;
            }
            Value = value;
        }

        protected abstract void Init();
    }
}
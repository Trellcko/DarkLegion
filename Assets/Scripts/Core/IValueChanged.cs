using System;

namespace DarkLegion.Core
{
    public interface IValueChanged
    {
        public float GetValue();
        public event Action Changed;
    }
}
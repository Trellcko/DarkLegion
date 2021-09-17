using DarkLegion.Unit.Stat;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillEffectOfIncreasingMovement : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private int _value;

        [SerializeField] private int _duration;

        [SerializeField] private bool _isFixed;

        public void Do(List<ComponentStorage> units)
        {
            foreach(var unit in units)
            {
                var buffOfIncreasingMovement = new BuffOfIncreasingMovement(unit.Movement, _value, _duration, _isFixed);
                unit.BuffStorage.Add(buffOfIncreasingMovement);
            }
        }
    }
}
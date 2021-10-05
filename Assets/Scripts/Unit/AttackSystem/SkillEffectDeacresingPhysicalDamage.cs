using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillEffectDeacresingPhysicalDamage : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private float _value;
        
        [SerializeField] private int _duration;

        [SerializeField] private bool _isFixed;
        
        public void Do(List<ComponentStorage> componentStorages)
        {
            foreach(var unit in componentStorages)
            {
                unit.BuffStorage.Add(new BuffOfDeacreasingPhysicalDamage(unit.PhysicalDamage, _value, _duration, _isFixed));
            }
        }
    }
}
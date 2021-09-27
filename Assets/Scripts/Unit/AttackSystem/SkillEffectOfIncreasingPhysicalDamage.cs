using DarkLegion.Unit;
using DarkLegion.Unit.AttackSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectOfIncreasingPhysicalDamage : MonoBehaviour, ISkillEffect
{
    [SerializeField] private float _value;

    [SerializeField] private int _duration;

    [SerializeField] private bool _isFixed;

    public void Do(List<ComponentStorage> units)
    {
        foreach (var unit in units)
        {
            var buffOfIncreasingMovement = new BuffOfIncreasingPhysicalDamage(unit.PhysicalDamage, _value, _duration, _isFixed);
            unit.BuffStorage.Add(buffOfIncreasingMovement);
        }
    }
}

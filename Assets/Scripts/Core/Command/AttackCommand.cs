using DarkLegion.Core.Command;
using DarkLegion.Unit;
using DarkLegion.Unit.AttackSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    public event Action Completed;
    public event Action Canceled;

    private List<ComponentStorage> _targets;
    private Skill _unitsSkill;
    private ComponentStorage _unit;

    public AttackCommand(ComponentStorage unit, int skillIndex,  List<ComponentStorage> targets)
    {
        _unitsSkill = unit.UnitSkillSet.Skills[skillIndex];
        _targets = targets;
        _unit = unit;
    }

    public void Execute()
    {
        _unitsSkill.Do(_unit, _targets);
        Completed?.Invoke();
    }

    /// <summary>
    /// Witout Realization((
    /// </summary>
    public void Undo()
    {
        throw new NotImplementedException();
    }
}

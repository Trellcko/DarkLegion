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

    private List<ComponentStorage> _targets;
    private Skill _unitsSkill;

    public AttackCommand(ComponentStorage unit, int skillIndex,  List<ComponentStorage> targets)
    {
        _unitsSkill = unit.SkillSet[skillIndex];
        _targets = targets;
    }

    public void Execute()
    {
        _unitsSkill.Do(_targets);
        Completed?.Invoke();
    }
}

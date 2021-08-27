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

    public AttackCommand(Skill unitSkill,  List<ComponentStorage> targets)
    {
        _unitsSkill = unitSkill;
        _targets = targets;
    }

    public void Execute()
    {
        _unitsSkill.Do(_targets);
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

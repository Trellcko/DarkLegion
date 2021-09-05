using DarkLegion.Unit.Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit
{
    public class ActionPoints : BaseStat
    {
        [SerializeField] private BaseStats _baseStats;
        protected override void Init()
        {
            Value = _baseStats.AttackPointsCount;
        }

    }
}
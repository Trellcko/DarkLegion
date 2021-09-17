using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DarkLegion.Unit.Stat;

namespace DarkLegion.Unit.AttackSystem
{
    public class BuffOfIncreasingMovement : Buff<Movement>
    {
        public BuffOfIncreasingMovement(Movement stat, float value, int duration, bool isFixed = true, bool isInfinity = false) : base(stat, value, duration, true, isFixed, isInfinity)
        {
        }

    }
}
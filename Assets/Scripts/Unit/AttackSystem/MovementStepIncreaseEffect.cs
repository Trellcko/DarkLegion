using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class MovementStepIncreaseEffect : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private int _multiply;
        public void Do(ComponentStorage who, List<ComponentStorage> targets)
        {
            who.Movement.Set(who.Movement.Value * _multiply);
        }
    }
}
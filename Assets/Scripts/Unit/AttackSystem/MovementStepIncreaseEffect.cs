using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class MovementStepIncreaseEffect : MonoBehaviour, ISkillEffect
    {
        [SerializeField] private int _multiply;
        public void Do(List<ComponentStorage> targets)
        {
            foreach(var target in targets)
            {
                target.Movement.Set(target.Movement.Value * _multiply);
            }
        }
    }
}
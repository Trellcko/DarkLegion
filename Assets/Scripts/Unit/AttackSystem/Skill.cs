using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    [Serializable]
    public class Skill
    {
        [SerializeField] private Sprite _icon;

        [SerializeReference] private List<ISkillEffect> _skillEffects;

        [SerializeField] private List<Transform> _targetedCells;

        [SerializeField] private string _description;

        public Sprite AttackIcon => _icon;

        public List<Transform> TargetedCells => _targetedCells;

        public string Description => _description;

        public void Do(List<ComponentStorage> targets)
        {
            foreach(var effect in _skillEffects)
            {
                effect.Do(targets);
            }
        }

    }
}
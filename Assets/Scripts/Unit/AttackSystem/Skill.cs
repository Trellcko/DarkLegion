using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    [Serializable]
    public class Skill
    {
        [SerializeField] private Sprite _icon;

        [SerializeField] private List<GameObject> _skillEffectsGO;
        [SerializeField] private List<Transform> _targetedCells;

        [SerializeField] private string _description;

        public Sprite AttackIcon => _icon;

        public List<Transform> TargetedCells => _targetedCells;

        public List<ISkillEffect> SkillEffects
        {
            get
            {
                if (_skillEffects == null)
                {
                    _skillEffects = new List<ISkillEffect>();

                    foreach (var attackEffectsGo in _skillEffectsGO)
                    {
                        if (attackEffectsGo.TryGetComponent(out ISkillEffect attackEffect))
                        {
                            _skillEffects.Add(attackEffect);
                        }

                    }
                }
                return _skillEffects;
            }
        }

        public string Description => _description;

        private List<ISkillEffect> _skillEffects;


        public void Do(List<ComponentStorage> targets)
        {
            foreach(var effect in SkillEffects)
            {
                effect.Do(targets);
            }
        }

    }
}
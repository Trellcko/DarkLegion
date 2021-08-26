using DarkLegion.Field.AttackSystem;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Unit
{
    [Serializable]
    public class Skill
    {
        [SerializeField] private Sprite _icon;

        [SerializeField] private List<GameObject> _attackEffectsGO;
        [SerializeField] private List<Transform> _attackedCell;

        [SerializeField] private string _description;

        public Sprite AttackIcon => _icon;

        public List<Transform> AttackedCell => _attackedCell;

        public List<IAttackEffect> AttackEffects
        {
            get
            {
                if (_attackEffects == null)
                {
                    _attackEffects = new List<IAttackEffect>();

                    foreach (var attackEffectsGo in _attackEffectsGO)
                    {
                        if (attackEffectsGo.TryGetComponent(out IAttackEffect attackEffect))
                        {
                            _attackEffects.Add(attackEffect);
                        }

                    }
                }
                return _attackEffects;
            }
        }

        public string Description => _description;

        private List<IAttackEffect> _attackEffects;


    }
}
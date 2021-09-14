using Sirenix.OdinInspector;
using Sirenix.Serialization;

using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class Skill : SerializedMonoBehaviour
    {
        [field: SerializeField] public Transform StartPoint { get; private set; }

        [field: SerializeField] public Sprite AttackIcon { get; private set; }

        [field: SerializeField] public List<Vector3> TargetedCoordiantes { get; private set; }

        [field: SerializeField] public string Description { get; private set; }
        
        [field: SerializeField] public int Cost { get; private set; }

        [OdinSerialize] private List<ISkillEffect> _skillEffects;

        public void Do(List<ComponentStorage> targets)
        {
            foreach(var effect in _skillEffects)
            {
                effect.Do(targets);
            }
        }

    }
}
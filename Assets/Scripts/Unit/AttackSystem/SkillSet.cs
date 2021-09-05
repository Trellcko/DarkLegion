using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillSet : SerializedMonoBehaviour
    {
        public int Count => _skills.Count;

        [SerializeField] private List<Skill> _skills;

        public Skill this[int index]
        {
            get
            {
                return _skills[index];
            }
        }

    }
}
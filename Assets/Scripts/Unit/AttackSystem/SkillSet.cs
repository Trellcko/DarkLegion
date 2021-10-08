using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillSet : MonoBehaviour
    {
        [SerializeField] private List<Skill> _skills;

        public int Count => _skills.Count;

        public bool Has(Skill skill) => _skills.IndexOf(skill) != -1;

        public int IndexOf(Skill skill) => _skills.IndexOf(skill);

        public Skill this[int index]
        {
            get
            {
                return _skills[index];
            }
        }

    }
}
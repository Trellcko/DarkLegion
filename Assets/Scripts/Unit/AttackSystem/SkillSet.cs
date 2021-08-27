using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Unit.AttackSystem
{
    public class SkillSet : MonoBehaviour
    {
        [SerializeField] private List<Skill> _skills;

        public List<Skill> Skills => _skills;
    }
}
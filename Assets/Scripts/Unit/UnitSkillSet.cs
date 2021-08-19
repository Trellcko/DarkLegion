using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Units
{
    public class UnitSkillSet : MonoBehaviour
    {
        [SerializeField] private List<UnitSkill> _skills;

        public List<UnitSkill> Skills => _skills;
    }
}
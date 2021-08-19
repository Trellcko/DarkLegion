using DarkLegion.Core.Command;
using UnityEngine;

namespace DarkLegion.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private CommandHandler _commandHandler;
        
        [SerializeField] private Animator _animator;

        [SerializeField] private UnitData _data;
        [SerializeField] private UnitSkillSet _unitSkillSet;

        public CommandHandler CommandHandler => _commandHandler;

        public Animator Animator => _animator;

        public UnitData UnitData => _data;
        public UnitSkillSet UnitSkillSet => _unitSkillSet;
    }
}
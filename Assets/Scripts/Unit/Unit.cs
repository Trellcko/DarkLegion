using DarkLegion.Core.Command;
using UnityEngine;

namespace DarkLegion.Units
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private CommandHandler _commandHandler;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        [SerializeField] private UnitData _data;

        public CommandHandler CommandHandler => _commandHandler;

        public SpriteRenderer SpriteRender => _spriteRenderer;
        public Animator Animator => _animator;

        public UnitData UnitData => _data;
    }
}
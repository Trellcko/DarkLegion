
using DarkLegion.Units;
using System;
using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class MovementAnimationPlayCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private readonly AnimatorHandler _animator;

        private readonly int _hashNamePreviouseState;

        public MovementAnimationPlayCommand(AnimatorHandler animator)
        {
            _hashNamePreviouseState = animator.GetCurrentState();
            _animator = animator;    
        }

        public void Execute()
        {
            _animator.PlayMovementAnimation();
            Completed?.Invoke();
            Completed = null;
        }

        public void Undo()
        {
            _animator.PlayState(_hashNamePreviouseState);
            Canceled?.Invoke();
            Canceled = null;
        }
    }
}
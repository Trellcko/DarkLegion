using DarkLegion.Unit;
using System;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class IdleAnimationPlayCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private readonly AnimatorHandler _animator;

        private readonly int _hashNamePreviouseState;

        public IdleAnimationPlayCommand(AnimatorHandler animator)
        {
            _hashNamePreviouseState = animator.GetCurrentState();
            _animator = animator;
        }

        public void Execute()
        {
            _animator.PlayIdleAnimation();
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

using DarkLegion.Unit;
using System;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class IdleAnimationPlayCommand : ICommand
    {
        public event Action Completed;

        private readonly AnimatorHandler _animator;

        public IdleAnimationPlayCommand(AnimatorHandler animator)
        {
            _animator = animator;
        }

        public void Execute()
        {
            _animator.PlayIdleAnimation();
            Completed?.Invoke();
            Completed = null;
        }
    }
}

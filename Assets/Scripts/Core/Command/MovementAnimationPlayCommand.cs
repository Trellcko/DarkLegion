
using DarkLegion.Unit;
using System;
using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class MovementAnimationPlayCommand : ICommand
    {
        public event Action Completed;

        private readonly AnimatorHandler _animator;

        public MovementAnimationPlayCommand(AnimatorHandler animator)
        {
            _animator = animator;    
        }

        public void Execute()
        {
            _animator.PlayMovementAnimation();
            Completed?.Invoke();
            Completed = null;
        }
    }
}
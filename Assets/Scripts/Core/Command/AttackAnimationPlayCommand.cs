using DarkLegion.Units;
using System;
using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class AttackAnimationPlayCommand : ICommand
    {
        /// <summary>
        /// Call when Animation Event Called 
        /// </summary>
        public event Action Completed;
        
        public event Action Canceled;

        private readonly AnimatorHandler _animator;

        private readonly int _attackAnimationIndex;

        private readonly int _hashNamePreviouseState;

        public AttackAnimationPlayCommand(AnimatorHandler animator, int attackAnimationindex)
        {
            _animator = animator;
            _attackAnimationIndex = attackAnimationindex;
            _hashNamePreviouseState = animator.GetCurrentState();
            _animator.AttackAnimationFinished += Complete;

        }

        public void Execute()
        {
            _animator.PlayAttackAnimation(_attackAnimationIndex);
        }

        public void Undo()
        {
            _animator.PlayState(_hashNamePreviouseState);
            Canceled?.Invoke();
            Canceled = null;
        }

        private void Complete()
        {
            Completed?.Invoke();
            Completed = null;
        }

    }
}
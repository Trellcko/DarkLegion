using DarkLegion.Unit;
using System;

namespace DarkLegion.Core.Command
{
    public class AttackAnimationPlayCommand : ICommand
    {
        /// <summary>
        /// Call when Animation Event Called 
        /// </summary>
        public event Action Completed;

        private readonly AnimatorHandler _animator;

        private readonly int _attackAnimationIndex;

        public AttackAnimationPlayCommand(AnimatorHandler animator, int attackAnimationindex)
        {
            _animator = animator;
            _attackAnimationIndex = attackAnimationindex;
            _animator.AttackAnimationFinished += Complete;

        }

        public void Execute()
        {
            _animator.PlayAttackAnimation(_attackAnimationIndex);
        }

        private void Complete()
        {
            Completed?.Invoke();
            Completed = null;
        }

    }
}
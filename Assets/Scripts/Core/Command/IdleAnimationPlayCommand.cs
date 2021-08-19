using System;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class IdleAnimationPlayCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private Animator _animator;

        private int _hashNamePreviouseState;

        private const string TriggerName = "Idle";

        public IdleAnimationPlayCommand(Animator animator)
        {
            _hashNamePreviouseState = animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
            _animator = animator;
        }

        public void Execute()
        {
            _animator.SetTrigger(TriggerName);
            Completed?.Invoke();
            Completed = null;
        }

        public void Undo()
        {
            _animator.Play(_hashNamePreviouseState);
            Canceled?.Invoke();
            Canceled = null;
        }
    }
}

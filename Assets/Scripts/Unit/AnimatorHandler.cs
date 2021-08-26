using System;

using UnityEngine;

namespace DarkLegion.Unit
{
    public class AnimatorHandler : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public event Action AttackAnimationFinished;

        private const string AttackTriggerName = "Attack";
        private const string MoveTriggerName = "Move";
        private const string IdleTriggerName = "Idle";
        private const string AttackIndexName = "AttackIndex";

        public int GetCurrentState()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
        }

        public void PlayState(int index)
        {
            _animator.Play(index);
        }

        public void PlayMovementAnimation()
        {
            _animator.SetTrigger(MoveTriggerName);
        }

        public void PlayIdleAnimation()
        {
            _animator.SetTrigger(IdleTriggerName);
        }

        public void PlayAttackAnimation(int index)
        {
            _animator.SetInteger(AttackIndexName, index);
            _animator.SetTrigger(AttackTriggerName);
        }
        /// <summary>
        /// Only for Animation Event
        /// </summary>
        public void CallAttackAnimationFinished()
        {
            AttackAnimationFinished?.Invoke();
            
        }

    }
}
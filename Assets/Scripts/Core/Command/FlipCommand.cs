using DarkLegion.Core.Command;

using System;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class FlipCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private SpriteRenderer _spriteRender;
        private bool _isLeft = false;

        private bool _initialValue;

        public FlipCommand(SpriteRenderer spriteRenderer)
        {
            _spriteRender = spriteRenderer;
            _isLeft = !_spriteRender.flipX;
            _initialValue = _spriteRender.flipX;
        }

        public FlipCommand(SpriteRenderer spriteRenderer, bool isLeft)
        {
            _spriteRender = spriteRenderer;
            _isLeft = isLeft;
            _initialValue = _spriteRender.flipX;
        }

        public void Execute()
        {
            _spriteRender.flipX = _isLeft;
            Completed?.Invoke();
            Completed = null;
        }

        public void Undo()
        {
            _spriteRender.flipX = _initialValue;
            Canceled?.Invoke();
            Canceled = null;
        }
    }
}
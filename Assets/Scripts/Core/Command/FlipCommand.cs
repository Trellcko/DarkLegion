using DarkLegion.Core.Command;

using System;

using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class FlipCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private readonly Transform _transform;
        private readonly float _flipValue = 1;

        private readonly float _initialValue;

        public FlipCommand(Transform transform)
        {
            _transform = transform;
            _flipValue = transform.localScale.x * -1;
            _initialValue = transform.localScale.x;
        }

        public FlipCommand(Transform transform, bool isLeft)
        {
            _transform = transform;
            _flipValue = isLeft? -1 : 1;
            _initialValue = transform.localScale.x;
        }

        public void Execute()
        {
            ChangeScale(_flipValue);

            Completed?.Invoke();
            Completed = null;
        }

        public void Undo()
        {
            ChangeScale(_initialValue);

            Canceled?.Invoke();
            Canceled = null;
        }

        private void ChangeScale(float xValue)
        {
            Vector3 theScale = _transform.localScale;
            theScale.x = xValue;
            _transform.localScale = theScale;
        }
    }
}
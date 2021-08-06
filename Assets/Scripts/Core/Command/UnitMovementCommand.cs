using DG.Tweening;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class UnitMovementCommand : ICommand
    {
        public event Action Completed;
        public event Action Canceled;

        private readonly Transform _transform;

        private readonly Vector2 _targetPosition;
        private readonly Vector2 _initPosition;

        private readonly float _duration = 2f;

        public UnitMovementCommand(Transform transform, Vector2 targetPosition)
        {
            _transform = transform;
            _initPosition = transform.position;
            _targetPosition = targetPosition;
        }

        public UnitMovementCommand(Transform transform, Vector2 targetPosition, float duration)
        {
            _transform = transform;
            _initPosition = transform.position;
            _targetPosition = targetPosition;
            _duration = duration;
        }

        public void Execute()
        {
            _transform.DOMove(_targetPosition, _duration).OnComplete(Completed.Invoke);
        }

        public void Undo()
        {
            _transform.position = _initPosition;
            Canceled.Invoke();
        }
    }
}
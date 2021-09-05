using DG.Tweening;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Core.Command
{
    public class MovementCommand : ICommand
    {
        public event Action Completed;

        private readonly Transform _transform;

        private readonly Vector2 _targetPosition;

        private readonly float _duration = 2f;

        public MovementCommand(Transform transform, Vector2 targetPosition)
        {
            _transform = transform;
            _targetPosition = targetPosition;
        }

        public MovementCommand(Transform transform, Vector2 targetPosition, float duration)
        {
            _transform = transform;
            _targetPosition = targetPosition;
            _duration = duration;
        }

        public void Execute()
        {
            _transform.DOMove(_targetPosition, _duration).SetEase(Ease.Linear).OnComplete( () => 
            { 
                Completed?.Invoke();
                Completed = null;
            });
        }
    }
}
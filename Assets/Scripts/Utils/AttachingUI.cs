using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkLegion.Utils
{
    public class AttachingUI : MonoBehaviour
    {
        [SerializeField] private RectTransform _self;

        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _offset = new Vector3(0, 5);

        private Vector3 _lastTargetPosition;

        private void LateUpdate()
        {
            TryChangePosition();
        }

        public void SetTarget(Transform transform)
        {
            _target = transform;
            _lastTargetPosition = _self.transform.position;
        }

        private void TryChangePosition()
        {
            if (_target && Vector3.Distance(_target.position, _lastTargetPosition) > 0.01f)
            {
                _self.transform.position = _target.position + _offset;
                _lastTargetPosition = _target.position;
            }

        }
    }
}
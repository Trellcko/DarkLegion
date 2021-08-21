using DarkLegion.Input;
using DarkLegion.Physics;

using System;

using UnityEngine;
using UnityEngine.InputSystem;

namespace DarkLegion.Utils
{
    public abstract class Selecting<T> : MonoBehaviour where T : Component
    {
        [SerializeField] private LayerMask _layers;

        public event Action Selected = delegate { };
        public event Action UnSelected = delegate { };

        public T LastSelected { get; private set; }
        public T LastSelectedOrNull { get; private set; }

        private bool _isBlocked = false;

        private readonly Raycaster _raycaster = new Raycaster();

        private void OnEnable()
        {
            InputHandler.Instance.LeftButtonClicked.performed += TrySelect;
        }

        private void OnDisable()
        {
            InputHandler.Instance.LeftButtonClicked.performed -= TrySelect;
        }

        public void SelectLastUnit()
        {
            LastSelectedOrNull = LastSelected;
            Selected?.Invoke();
        }

        public void TrySelect(Vector3 position)
        {
            if (_isBlocked) return;

            LastSelectedOrNull = _raycaster.Hit<T>(position, _layers);
            if (LastSelectedOrNull)
            {
                LastSelected = LastSelectedOrNull;
                Selected?.Invoke();
                return;
            }
            UnSelected?.Invoke();
        }

        private void TrySelect(InputAction.CallbackContext obj)
        {
            TrySelect(InputHandler.Instance.GetMousePosition());
        }

    }
}
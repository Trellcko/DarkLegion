using DarkLegion.Input;
using DarkLegion.Physics;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace DarkLegion.Field {
    public class Selecting : MonoBehaviour
    {
        [SerializeField] private LayerMask _layers;

        public UnityEvent Selected;
        public UnityEvent UnSelected;

        public Transform LastSelected { get; private set; }
        public Transform LastSelectedOrNull { get; private set; }

        private readonly Raycaster _raycaster = new Raycaster();

        private void OnEnable()
        {
            InputHandler.Instance.LeftButtonClicked.performed += TrySelect;
        }

        private void OnDisable()
        {
            InputHandler.Instance.LeftButtonClicked.performed -= TrySelect;
        }

        private void TrySelect(InputAction.CallbackContext obj)
        {
            LastSelectedOrNull = _raycaster.Hit<Transform>(InputHandler.Instance.GetMousePosition(), _layers);
            if (LastSelectedOrNull)
            {
                LastSelected = LastSelectedOrNull;
                Selected.Invoke();
                return;
            }
            UnSelected.Invoke();
        }

    }
}
using UnityEngine;
using UnityEngine.InputSystem;

namespace DarkLegion.Input
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new GameObject().AddComponent<InputHandler>();
                }
                return s_instance;
            }
        }
        public InputAction LeftButtonClicked => _inputData.Field.LeftButtonClick;
        
        private static InputHandler s_instance;

        private InputData _inputData;

        private Camera _camera;
     
        private void Awake()
        {
            if(s_instance != null)
            {
                Destroy(this);
            }
            s_instance = this;
            DontDestroyOnLoad(gameObject);

            _camera = Camera.main;
            _inputData = new InputData();
        }

        private void OnEnable()
        {
            _inputData.Enable();
        }

        private void OnDisable()
        {
            _inputData.Disable();
        }

        public Vector2 GetMousePosition()
        {
            var pos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            return _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        }

    }
}
// GENERATED AUTOMATICALLY FROM 'Assets/ScriptableObjects/InputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace DarkLegion.Input
{
    public class @InputData : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @InputData()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputAction"",
    ""maps"": [
        {
            ""name"": ""Field"",
            ""id"": ""7cbae0ab-559d-47fc-9f82-82f9028303b0"",
            ""actions"": [
                {
                    ""name"": ""LeftButtonClick"",
                    ""type"": ""Button"",
                    ""id"": ""3de6c940-0d3e-4e8b-b3f3-a52888b1bdc8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""3c88285a-7d1c-4fe9-b9aa-c7bccc3ad6f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5899176a-7873-43b2-8ded-5975884fd3fa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftButtonClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a7337ae7-cfb6-4001-a0ac-aa901df5ca9f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""73b51b7b-ab1c-43a5-a9e5-2e47b97be5d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ca1ae737-a858-4196-a8d9-3c9ab4445b66"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Field
            m_Field = asset.FindActionMap("Field", throwIfNotFound: true);
            m_Field_LeftButtonClick = m_Field.FindAction("LeftButtonClick", throwIfNotFound: true);
            m_Field_Movement = m_Field.FindAction("Movement", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Field
        private readonly InputActionMap m_Field;
        private IFieldActions m_FieldActionsCallbackInterface;
        private readonly InputAction m_Field_LeftButtonClick;
        private readonly InputAction m_Field_Movement;
        public struct FieldActions
        {
            private @InputData m_Wrapper;
            public FieldActions(@InputData wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftButtonClick => m_Wrapper.m_Field_LeftButtonClick;
            public InputAction @Movement => m_Wrapper.m_Field_Movement;
            public InputActionMap Get() { return m_Wrapper.m_Field; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(FieldActions set) { return set.Get(); }
            public void SetCallbacks(IFieldActions instance)
            {
                if (m_Wrapper.m_FieldActionsCallbackInterface != null)
                {
                    @LeftButtonClick.started -= m_Wrapper.m_FieldActionsCallbackInterface.OnLeftButtonClick;
                    @LeftButtonClick.performed -= m_Wrapper.m_FieldActionsCallbackInterface.OnLeftButtonClick;
                    @LeftButtonClick.canceled -= m_Wrapper.m_FieldActionsCallbackInterface.OnLeftButtonClick;
                    @Movement.started -= m_Wrapper.m_FieldActionsCallbackInterface.OnMovement;
                    @Movement.performed -= m_Wrapper.m_FieldActionsCallbackInterface.OnMovement;
                    @Movement.canceled -= m_Wrapper.m_FieldActionsCallbackInterface.OnMovement;
                }
                m_Wrapper.m_FieldActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @LeftButtonClick.started += instance.OnLeftButtonClick;
                    @LeftButtonClick.performed += instance.OnLeftButtonClick;
                    @LeftButtonClick.canceled += instance.OnLeftButtonClick;
                    @Movement.started += instance.OnMovement;
                    @Movement.performed += instance.OnMovement;
                    @Movement.canceled += instance.OnMovement;
                }
            }
        }
        public FieldActions @Field => new FieldActions(this);
        public interface IFieldActions
        {
            void OnLeftButtonClick(InputAction.CallbackContext context);
            void OnMovement(InputAction.CallbackContext context);
        }
    }
}

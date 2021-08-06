using DarkLegion.Core.Command;
using DarkLegion.Input;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommander : MonoBehaviour
{
    [SerializeField] private GridHandler _gridHandler;

    private Vector2 _previousClickPosition;

    public void Start()
    {
        InputHandler.Instance.InputAction.Field.LeftButtonClick.performed += OnLeftButtonClick;
    }

    private void OnLeftButtonClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }
}

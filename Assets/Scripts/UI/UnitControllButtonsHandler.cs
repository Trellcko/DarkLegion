using DarkLegion.Field;

using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.UI
{
    public class UnitControllButtonsHandler : MonoBehaviour
    {
        [SerializeField] private List<SkillButton> _buttons;

        [SerializeField] private FlipButton _flipButton;
        [SerializeField] private TurnSystem _turnSystem;

        private event Action _turnChangedHandler; 

        private void Awake()
        { 
            Hide();
            _turnChangedHandler = () =>
            {
                if (_turnSystem.IsPlayerTurn)
                {
                    Show();
                    return;
                }
                Hide();
            };
        }

        private void OnEnable()
        {
            _turnSystem.TurnChanged += _turnChangedHandler;
        }

        private void OnDisable()
        {
            _turnSystem.TurnChanged -= _turnChangedHandler;
        }

        private void Show()
        {
            for (int i = 0; i < _turnSystem.ActiveUnit.UnitSkillSet.Count; i++)
            {
                _buttons[i].SetData(_turnSystem.ActiveUnit.UnitSkillSet[i]);
                _buttons[i].Show();
            }
            _flipButton.Show();
        }

        private void Hide()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].TryHide();
            }
            _flipButton.TryHide();
        }
    }
}
using DarkLegion.Field;
using DarkLegion.Unit;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.UI
{
    public class UnitButtonsHandler : MonoBehaviour
    {
        [SerializeField] private List<SkillButton> _skillButtons;

        [SerializeField] private FlipButton _flipButton;
        [SerializeField] private TurnSystem _turnSystem;
        [SerializeField] private PlayerCommander _playerCommander;

        private Action _turnChangedHandler;
        private Action<bool> _unitCompletedCommandsHandler;

        private Action<int> _skillButtonClickedHandler;
        private Action _flipButtonClickedHandler;

        private void Awake()
        { 
            Hide();
            _turnChangedHandler += () =>
            {

                Hide();
                if (_turnSystem.IsPlayerTurn)
                {
                    Show();
                    TryChangeButtonInteractive();
                    return;
                }
            };
            _unitCompletedCommandsHandler += (hasPoints) => { if (hasPoints) TryChangeButtonInteractive(); };
            _skillButtonClickedHandler += i => { _playerCommander.TryUseSkill(_turnSystem.ActiveUnit, i); };
            _flipButtonClickedHandler += () => { _playerCommander.TryFlip(_turnSystem.ActiveUnit); };
        }

        private void OnEnable()
        {
            _playerCommander.UnitAttacked += _unitCompletedCommandsHandler;
            _playerCommander.UnitMoved += _unitCompletedCommandsHandler;
         
            _turnSystem.TurnChanged += _turnChangedHandler;

            foreach (var button in _skillButtons)
            {
                button.SkillButtonClicked += _skillButtonClickedHandler;
            }

            _flipButton.Clicked += _flipButtonClickedHandler;
            
        }

        private void OnDisable()
        {
            _playerCommander.UnitAttacked -= _unitCompletedCommandsHandler;
            _playerCommander.UnitMoved -= _unitCompletedCommandsHandler;
            
            _turnSystem.TurnChanged -= _turnChangedHandler;

            foreach (var button in _skillButtons)
            {
                button.SkillButtonClicked -= _skillButtonClickedHandler;
            }

            _flipButton.Clicked -= _flipButtonClickedHandler;
        }

        private void Show()
        {
            for (int i = 0; i < _turnSystem.ActiveUnit.SkillSet.Count; i++)
            {
                _skillButtons[i].EnableInteractive();
                _skillButtons[i].SetData(_turnSystem.ActiveUnit.SkillSet[i]);
                _skillButtons[i].Show();
            }
            _flipButton.Show();
        }

        private void TryChangeButtonInteractive()
        {
            for (int i = 0; i < _turnSystem.ActiveUnit.SkillSet.Count; i++)
            {
                if (_turnSystem.ActiveUnit.ActionPoints.Value < _turnSystem.ActiveUnit.SkillSet[i].Cost)
                {
                    _skillButtons[i].DisableInteractive();
                }
            }
        }

        private void Hide()
        {
            for (int i = 0; i < _skillButtons.Count; i++)
            {
                _skillButtons[i].Hide();
            }
            _flipButton.Hide();
        }
    }
}
using DarkLegion.Field;
using DarkLegion.Field.Visuzalization;
using DarkLegion.Unit.AttackSystem;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace DarkLegion.UI
{
    public class SkillButtonsHandler : MonoBehaviour
    {
        [SerializeField] private List<SkillButton> _skillButtons;

        [SerializeField] private FlipButton _flipButton;
        [SerializeField] private TurnSystem _turnSystem;

        [SerializeField] private AttackVizualizationHandler _attackVizualizationHandler;
        [SerializeField] private PlayerCommander _playerCommander;

        private Action _turnChangedHandler;


        private Action<bool> _unitCompletedCommandsHandler;

        private Action<Skill> _skillButtonClickedHandler;
        private Action<Skill> _skillButtonEnteredHandler;
        private Action<Skill> _skillButtonExitedHandler;

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
            
            _flipButtonClickedHandler += () => { _playerCommander.TryFlip(_turnSystem.ActiveUnit); };

            _skillButtonClickedHandler += (skill) => { _playerCommander.TryUseSkill(_turnSystem.ActiveUnit, skill); };
            _skillButtonEnteredHandler += _attackVizualizationHandler.Show;
            _skillButtonExitedHandler += _attackVizualizationHandler.Hide;
        }

        private void OnEnable()
        {
            _playerCommander.UnitAttacked += _unitCompletedCommandsHandler;
            _playerCommander.UnitMoved += _unitCompletedCommandsHandler;
         
            _turnSystem.TurnChanged += _turnChangedHandler;

            foreach (var button in _skillButtons)
            {
                button.Clicked += _skillButtonClickedHandler;
                button.PointerEntered += _skillButtonEnteredHandler;
                button.PointerExited += _skillButtonExitedHandler;
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
                button.Clicked -= _skillButtonClickedHandler;
                button.PointerEntered -= _skillButtonEnteredHandler;
                button.PointerExited -= _skillButtonExitedHandler;
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
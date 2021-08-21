using DarkLegion.Utils;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace DarkLegion.UI {
    public class ButtonsRegistrar : MonoBehaviour
    {
        [SerializeField] private List<SkillButton> _buttons;

        [SerializeField] private FlipButton _flipButton;

        [SerializeField] private UnitSelecting _playerUnitsSelecting;
        [SerializeField] private TransformSelecting _everythingSelecting;

        private void Awake()
        {
            Hide();
        }

        private void OnEnable()
        {
            _playerUnitsSelecting.Selected += Show;
            _everythingSelecting.UnSelected += Hide;
        }

        private void OnDisable()
        {
            _playerUnitsSelecting.Selected -= Show;
            _playerUnitsSelecting.UnSelected -= Hide;
        }

        private void Show()
        {
            for (int i = 0; i < _playerUnitsSelecting.LastSelected.UnitSkillSet.Skills.Count; i++)
            {
                _buttons[i].SetData(_playerUnitsSelecting.LastSelected.UnitSkillSet.Skills[i]);
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
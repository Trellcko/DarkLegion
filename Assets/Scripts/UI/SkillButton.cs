using DarkLegion.Field.Visuzalization;
using DarkLegion.Units;

using System;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Image))]
    public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _textPanel;

        [SerializeField] private AttackedCellVisualization _attackingCellVisualization;

        [SerializeField] private int _attackIndex;


        public event Action<int> SkillButtonClicked;

        private Image _image;

        private List<Transform> _lastSkillAttackedCell = new List<Transform>();

        private string _description = "";

        private bool _isMouseOver = false;
        private bool _isOff = true;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Show()
        {
            _image.enabled = true;
            _isOff = false;
        }

        public void SetData(UnitSkill skill)
        {
            _image.sprite = skill.AttackIcon;
            _description = skill.Description;
            _lastSkillAttackedCell = skill.AttackedCell;
        }

        public void TryHide()
        {
            if(_isMouseOver == false)
            {
                Hide();
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            PointerClick();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter();
        }


        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit();
        }

        private void PointerClick()
        {
            Hide();
            SkillButtonClicked?.Invoke(_attackIndex);
        }
        private void PointerEnter()
        {
            EnableText();

            _descriptionText.SetText(_description);
            ShowLastSkillAttackPoint();
            _isMouseOver = true;
        }
 
        private void PointerExit()
        {
            if (_isMouseOver == true)
            {
                DisableText();
                if (_isOff == true)
                {
                    _attackingCellVisualization.Clear();
                }
                else
                {
                    _attackingCellVisualization.ReturnPreviousColors();
                }
            }
            _isMouseOver = false;
        }

        private void Hide()
        {
            _image.enabled = false;
            _isOff = true;
            PointerExit();
        }

        private void EnableText()
        {
            _textPanel.enabled = true;
        }

        private void DisableText()
        {
            _textPanel.enabled = false;
        }

        private void ShowLastSkillAttackPoint()
        {
            _attackingCellVisualization.Show(_lastSkillAttackedCell);
        }
    }
}
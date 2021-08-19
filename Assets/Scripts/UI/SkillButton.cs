using DarkLegion.Units;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Button))]
    public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _textPanel;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Show()
        {
            _button.image.enabled = true;
        }

        public void SetData(UnitSkill skill)
        {
            _button.image.sprite = skill.AttackIcon;
            _descriptionText.SetText(skill.Description);
        }

        public void Hide()
        {
            _button.image.enabled = false;
            DisableText();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EnableText();
        }

        private void EnableText()
        {
            _textPanel.enabled = true;
            _descriptionText.enabled = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DisableText();
        }

        private void DisableText()
        {
            _textPanel.enabled = false;
            _descriptionText.enabled = false;
        }

    }
}
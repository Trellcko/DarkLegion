using DarkLegion.Field.Visuzalization;
using DarkLegion.Unit.AttackSystem;

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

        public event Action<Skill> Clicked;
        public event Action<Skill> PointerEntered;
        public event Action<Skill> PointerExited;

        private Image _image;
        
        private string _description = "";

        private Skill _skill;

        private bool _isInteractible = true;

        private readonly Color _interactibleColor = Color.white;
        private readonly Color _nonInteractibleColor = new Color(1, 1, 1, 0.5f);

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void EnableInteractive()
        {
            _isInteractible = true;
            _image.color = _interactibleColor;
        }    

        public void DisableInteractive()
        {
            _isInteractible = false;
            _image.color = _nonInteractibleColor;
        }

        public void Show()
        {
            _image.enabled = true;
        }
        public void Hide()
        {
            _image.enabled = false;
            PointerExit();
        }

        public void SetData(Skill skill)
        {
            _image.sprite = skill.AttackIcon;
            _description = skill.Description;
            _skill = skill;
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
            if (_isInteractible)
            {
                Clicked?.Invoke(_skill);
            }
        }

        private void PointerEnter()
        {
            EnableText();
            PointerEntered?.Invoke(_skill);
        }
 
        private void PointerExit()
        {
            DisableText();
            PointerExited?.Invoke(_skill);
        }

        private void EnableText()
        {
            _textPanel.enabled = true;
            _descriptionText.SetText(_description);
        }

        private void DisableText()
        {
            _textPanel.enabled = false;
            _descriptionText.SetText("");
        }
    }
}
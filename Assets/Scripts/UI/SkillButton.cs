using DarkLegion.Units;
using DarkLegion.Field.Visuzalization;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using System.Collections.Generic;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Button))]
    public class SkillButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _textPanel;

        [SerializeField] private AttackedCellVisualization _attackingCellVisualization;

        private Button _button;
        
        private List<Transform> _lastSkillAttackedCell = new List<Transform>();

        private string _description = "";

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {

            _button.onClick.AddListener(ShowLastSkillAttackPoint);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ShowLastSkillAttackPoint);
        }

        public void Show()
        {
            _button.image.enabled = true;
        }

        public void SetData(UnitSkill skill)
        {
            _button.image.sprite = skill.AttackIcon;
            _description = skill.Description;
            _lastSkillAttackedCell = skill.AttackedCell;
        }

        public void Hide()
        {
            _button.image.enabled = false;
            Debug.Log(name);
            DisableText();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            EnableText();
            _descriptionText.SetText(_description);
            ShowLastSkillAttackPoint();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DisableText();
            _attackingCellVisualization.Clear();
        }

        private void EnableText()
        {
            _textPanel.enabled = true;
            _descriptionText.enabled = true;
        }

        private void DisableText()
        {
            _textPanel.enabled = false;
            _descriptionText.enabled = false;
        }

        private void ShowLastSkillAttackPoint()
        {
            _attackingCellVisualization.Show(_lastSkillAttackedCell);
        }

    }
}
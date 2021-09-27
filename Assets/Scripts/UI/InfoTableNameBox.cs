using DarkLegion.Field;
using TMPro;
using UnityEngine;

namespace DarkLegion.UI
{
    public class InfoTableNameBox : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        [SerializeField] private TurnSystem _turnSystem;

        private void OnEnable()
        {
            _turnSystem.TurnChanged += SetNameActiveUnit;
        }

        private void OnDisable()
        {
            _turnSystem.TurnChanged -= SetNameActiveUnit;
        }

        private void SetNameActiveUnit()
        {
            _text.SetText(_turnSystem.ActiveUnit.BaseInfo.Name);
        }
    }
}
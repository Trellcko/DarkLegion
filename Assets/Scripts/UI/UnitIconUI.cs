using DarkLegion.Field;
using UnityEngine;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Image))]
    public class UnitIconUI : MonoBehaviour
    {
        [SerializeField] private TurnSystem _turnSystem;

        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _turnSystem.TurnChanged += ShowIconActiveUnit;
        }

        private void OnDisable()
        {
            _turnSystem.TurnChanged -= ShowIconActiveUnit;
        }
        private void ShowIconActiveUnit()
        {
            _image.sprite = _turnSystem.ActiveUnit.BaseInfo.TurnIcon;
        }
    }
}
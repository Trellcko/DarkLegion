using UnityEngine;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    public class TurnIcon : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _icon;

        public void Move()
        {

        }

        public void Set(Sprite background, Sprite icon)
        {
            _background.sprite = background;
            _icon.sprite = icon;
        }
    }
}
using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Image))]
    public class FlipButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public event Action Clicked;

        private Image _image;

        private bool _isMouseOver = false;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isMouseOver = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isMouseOver = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Hide();
            Clicked?.Invoke();
        }

        public void TryHide()
        {
            if (_isMouseOver == false)
            {
                Hide();
            }
        }

        public void Show()
        {
            _image.enabled = true;
        }

        public void Hide()
        {
            _image.enabled = false;
        }
    }
}
using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DarkLegion.UI
{
    [RequireComponent(typeof(Image))]
    public class FlipButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;

        private Image _image;


        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
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
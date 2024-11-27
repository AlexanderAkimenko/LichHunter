using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Services.Input
{
    public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        protected const string HORIZONTAL = "Horizontal";
        protected const string VERTICAL = "Vertical";
        
        [SerializeField] private Image _joystickBackground;
        [SerializeField] private Image _joystick;
        [SerializeField] private Image _joystickArea;

        private Vector2 _joystickBackgroundStartPosition;
        private Vector2 _inputVector;

        private bool _joystickUsed = false;

        private void Start()
        {
            _joystickBackgroundStartPosition = _joystickBackground.rectTransform.anchoredPosition;
        }

        
        public void OnDrag(PointerEventData eventData)
        {
           
            Vector2 joystickPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform,
                    eventData.position, null, out joystickPosition))
            {
                joystickPosition.x = (joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x);
                joystickPosition.y = (joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y);

                _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);
                _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;

                _joystick.rectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * (_joystickBackground.rectTransform.sizeDelta.x / 2),
                    _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));

            }
          
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _joystickUsed = true;
            Vector2 joystickBackgroundPosition;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position,
                    null, out joystickBackgroundPosition))
            {
                _joystickBackground.rectTransform.anchoredPosition =
                    new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
            }

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _joystickUsed = false;
            _joystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosition;

            _inputVector = Vector2.zero;
            _joystick.rectTransform.anchoredPosition = Vector2.zero;
        }

        

        public Vector2 GetAxis()
        {
            if (!_joystickUsed)
            {
                _inputVector = new Vector2(UnityEngine.Input.GetAxis(HORIZONTAL), UnityEngine.Input.GetAxis(VERTICAL)).normalized;
            }
          
            return _inputVector;
            
        }
    }
}
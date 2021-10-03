using System;
using Core;
using Core.EventHandlers;
using UnityEngine;

namespace Panel
{
    public class PanelButton : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private EventManager _events;
        
        public Sprite releasedSprite, pressedState;
        public string btnName;
        public bool toggle;

        public bool isPressed = false;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _events = FindObjectOfType<EventManager>();
        }

        private void OnMouseDown()
        {
            if (isPressed && !toggle) return;

            isPressed = !isPressed;
            _events.Raise(new InputEvent() {
                type = toggle ? InputEventType.Once : InputEventType.Start,
                value = $"btn:{btnName}"
            });
        }

        private void OnMouseUp()
        {
            if (!isPressed || toggle) return;

            isPressed = false;
            _events.Raise(new InputEvent() {
                type = InputEventType.End,
                value = $"btn:{btnName}"
            });
        }

        private void Update()
        {
            _renderer.sprite = isPressed ? pressedState : releasedSprite;
            
            if (!isPressed || toggle) return;
            
            _events.Raise(new InputEvent {
                type = InputEventType.Continue,
                value = $"btn:{btnName}"
            });
        }
    }
}
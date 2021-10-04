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

        public AudioSource _sound_1, _sound_2;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _events = FindObjectOfType<EventManager>();

            _sound_1 = GetComponentsInParent<AudioSource>()[0];
            _sound_2 = GetComponentsInParent<AudioSource>()[1];
        }

        private void OnMouseDown()
        {
            if (isPressed && !toggle) return;

            isPressed = !isPressed;
            _events.Raise(new InputEvent() {
                type = toggle ? InputEventType.Once : InputEventType.Start,
                value = $"btn:{btnName}"
            });

            if (toggle)
            {
                if (isPressed)
                    _sound_1.Play();
                else
                    _sound_2.Play();
            } else
            {
                // Button
                _sound_1.Play();
            }

        }

        private void OnMouseUp()
        {
            if (!isPressed || toggle) return;

            isPressed = false;
            _events.Raise(new InputEvent() {
                type = InputEventType.End,
                value = $"btn:{btnName}"
            });

            if (!toggle) // Button
            {
                _sound_2.Play();
            }
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
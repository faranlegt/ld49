using Core;
using Core.EventHandlers;
using Core.Models;
using UnityEngine;

namespace Panel
{
    public class Indicator : MonoBehaviour, IInputEventHandler
    {
        public bool on = false, blinkOn;

        public bool blinking;
        public float blinkTime = 0.5f, t;

        public string indicatorName;

        private SpriteRenderer _renderer;
        private EventManager _events;

        public void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _events = FindObjectOfType<EventManager>();

            _events.Register(this);
        }

        public void Update()
        {
            if (on && blinking)
            {
                _renderer.enabled = blinkOn;
                t -= Time.deltaTime;
                
                if (t < 0)
                {
                    t = blinkTime;
                    blinkOn = !blinkOn;
                }
            }
            else
            {
                _renderer.enabled = on;
            }
        }

        public string CodeName { get; }

        public InputEvent? Handle(InputEvent ev)
        {
            if (ev.value == indicatorName && ev.type == InputEventType.Start)
            {
                on = true;
            }

            if (ev.value == indicatorName && ev.type == InputEventType.End)
            {
                on = false;
            }
        
            return null;
        }
    }
}

using Core;
using Core.InputEventHandlers;
using Core.Models;
using UnityEngine;

namespace Panel
{
    public class LevelEndLed : MonoBehaviour, IInputEventHandler
    {
        private SpriteRenderer _renderer;

        public Sprite onSprite, offSprite;
    
        public float timeToLed = 0;
        public bool isOn;

        public string CodeName => "level_end_led";

        void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            var events = FindObjectOfType<EventManager>();

            events.Register(this);

            events.Register(
                Helpers.On(
                    "change_danger_time",
                    ev => ev.value.StartsWith("danger_time:"),
                    ev =>
                    {
                        var dangerTime = float.Parse(ev.value.Substring(12));

                        isOn = dangerTime > timeToLed;
                    }
                )
            );
        }

        public void Update()
        {
            _renderer.sprite = isOn ? onSprite : offSprite;
        }

        public InputEvent? Handle(InputEvent ev) => null;
    }
}
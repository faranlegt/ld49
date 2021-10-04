using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels.Rover
{
    public class RoverLevel : Level
    {
        private BuzzSoundsScript _buzzer;
        public override bool IsFailing => false;

        public override void Start()
        {
            base.Start();
            _buzzer = FindObjectOfType<BuzzSoundsScript>();
        }

        public override void ClearLevel()
        {
            base.ClearLevel();

            foreach (var led in new[] { "green", "yellow", "red", "purple" })
            {
                Events.Raise(new InputEvent {
                    type = InputEventType.End,
                    value = $"led:{led}"
                });
            }
        }

        public override void Update()
        {
            base.Update();
            
            if (!isPlaying) return;
        }

    }
}
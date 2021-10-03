using System;
using Core;
using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

namespace Levels
{
    public abstract class Level : MonoBehaviour, IInputEventHandler
    {
        public float failingTime = 0;
        public float levelGoing = 0, fullLevelTime = 60f;
        protected EventManager Events;

        public string CodeName => "level";

        public abstract bool IsFailing { get; }

        public virtual void Start()
        {
            Events = FindObjectOfType<EventManager>();
            Events.Register(this);
        }

        public virtual InputEvent? Handle(InputEvent ev) => null;

        public virtual void Update()
        {
            levelGoing += Time.deltaTime;
            
            if (IsFailing)
            {
                failingTime += Time.deltaTime;
                if (failingTime > 7)
                {
                    failingTime = 7.1f;
                }
            }
            else
            {
                failingTime -= Time.deltaTime;
                if (failingTime < 0)
                {
                    failingTime = 0;
                }
            }

            Events.Raise(new InputEvent {
                type = InputEventType.Start,
                value = $"danger_time:{failingTime}"
            });
        }
    }
}
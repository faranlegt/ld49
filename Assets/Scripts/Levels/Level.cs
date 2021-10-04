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

            Events.Register(Helpers.OnEvent("restart",
                _ =>
                {
                    failingTime = 0;
                    levelGoing = 0;
                })
            );
            
            Events.Register(new SinglePressHandler("btn:right").Named("restart"));
        }

        public virtual InputEvent? Handle(InputEvent ev) => null;

        public virtual void Update()
        {
            if (IsFailing)
            {
                failingTime += Time.deltaTime;
                if (failingTime > 7)
                {
                    return;
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
            levelGoing += Time.deltaTime;

            Events.Raise(new InputEvent {
                type = InputEventType.Start,
                value = $"danger_time:{failingTime}"
            });
        }
    }
}
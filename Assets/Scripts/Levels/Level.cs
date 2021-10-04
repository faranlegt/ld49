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
        public bool isPlaying = false;
        public float failingTime = 0;
        public float levelGoing = 0, fullLevelTime = 60f;
        public bool gameLostSent;
        protected EventManager Events;

        public string CodeName => "level";

        public abstract bool IsFailing { get; }

        public virtual void Start()
        {
            Events = FindObjectOfType<EventManager>();
            Events.Register(this);
            
            Events.Register(Helpers.OnEvent("lever-up",
                _ =>
                {
                    ClearLevel();
                    isPlaying = true;
                }));
            Events.Register(Helpers.OnEvent("lever-down", _ => ClearLevel()));
        }

        public virtual void ClearLevel()
        {
            isPlaying = false;
            failingTime = 0;
            levelGoing = 0;
            gameLostSent = false;
        }

        public virtual InputEvent? Handle(InputEvent ev) => null;

        public virtual void Update()
        {
            if (!isPlaying) return;

            if (levelGoing > fullLevelTime)
            {
                isPlaying = false;
                return;
            }
            
            if (IsFailing)
            {
                failingTime += Time.deltaTime;
                if (failingTime > 7)
                {
                    if (!gameLostSent)
                    {
                        gameLostSent = true;
                        Events.Raise(new InputEvent {
                            type = InputEventType.Start,
                            value = $"game_lost"
                        });
                    }
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
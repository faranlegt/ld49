using System;
using Core;
using Core.EventHandlers;
using Core.EventHandlers.Handlers;
using Core.Models;
using UnityEngine;

namespace Levels
{
    public class Level : MonoBehaviour, IInputEventHandler
    {
        public float levelGoing = 0, fullLevelTime = 60f;
        protected EventManager Events;

        public virtual void Start()
        {
            Events = FindObjectOfType<EventManager>();
            Events.Register(this);
        }

        public string CodeName => "level";

        public virtual InputEvent? Handle(InputEvent ev)
        {
            return null;
        }

        public virtual void Update()
        {
            levelGoing += Time.deltaTime;

            if (levelGoing > fullLevelTime)
            {
                
            }
        }
    }
}